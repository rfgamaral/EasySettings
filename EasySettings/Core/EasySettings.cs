#region Copyright © 2008-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Xsl;

namespace RA.Library.EasySettings {

    public sealed class EasySettings<T> {

        #region Private Fields

        private XmlDocument xDocument;
        private string xmlFilePath;
        private string xmlRootElement;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets the Data object from <see cref="EasySettings" /> containing all application settings.
        /// </summary>
        /// <value>The application settings.</value>
        public T Data {
            get;
            private set;
        }

        #endregion

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettings{T}" /> class with the specified settings XML file
        /// path and the assembly name as the XML root element.
        /// </summary>
        /// <param name="xmlFilePath">The settings XML file path.</param>
        public EasySettings(string xmlFilePath) {
            InitializeSettings(xmlFilePath, GetType().Assembly.GetName().Name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettings{T}" /> class with the specified settings XML file
        /// path and the specified XML root element.
        /// </summary>
        /// <param name="xmlFilePath">The settings XML file path.</param>
        /// <param name="xmlRootElement">The settings XML root element.</param>
        public EasySettings(string xmlFilePath, string xmlRootElement) {
            InitializeSettings(xmlFilePath, xmlRootElement);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves all the application settings to the XML file.
        /// </summary>
        public void Save() {
            // Create a new XML file if there's no root element
            if(xDocument.DocumentElement == null) {
                xDocument = new XmlDocument();
                xDocument.LoadXml(String.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n<{0}>\n</{0}>", xmlRootElement));
            }

            XmlAttribute xAttribute;
            XmlNode xCategory, xKey;

            // Loop through all properties in the Data class
            foreach(PropertyInfo property in GetProperties()) {
                // Search for the required setting attribute
                EasySettingAttribute attribute = (EasySettingAttribute)Attribute.GetCustomAttribute(property,
                    typeof(EasySettingAttribute));

                // Skip the current property if the setting attribute was not found
                if(attribute == null) {
                    continue;
                }

                // Select the XML node with the specified category name
                xCategory = xDocument.SelectSingleNode("//Category[@Name='" + attribute.CategoryName + "']");

                // Create the XML category node if it doesn't already exist
                if(xCategory == null) {
                    // Create the new category node
                    xCategory = xDocument.CreateNode(XmlNodeType.Element, "Category", null);

                    // Create a new name attribute and set the category name
                    xAttribute = xDocument.CreateAttribute("Name");
                    xAttribute.Value = attribute.CategoryName;

                    // Add the name attribute to the category node
                    xCategory.Attributes.SetNamedItem(xAttribute);

                    // Add the new category node to the XML root element
                    xDocument.DocumentElement.AppendChild(xCategory);
                }

                // Select the XML node with the specified key name
                xKey = xCategory.SelectSingleNode("descendant::Key[@Name='" + property.Name + "']");

                // Create the XML key node if it doesn't already exist
                if(xKey == null) {
                    // Create the new key node
                    xKey = xDocument.CreateNode(XmlNodeType.Element, "Key", null);

                    // Create a new name attribute and set the key name
                    xAttribute = xDocument.CreateAttribute("Name");
                    xAttribute.Value = property.Name;

                    // Add the name attribute to the key node
                    xKey.Attributes.SetNamedItem(xAttribute);

                    // Create a new value attribute and set the key value
                    xAttribute = xDocument.CreateAttribute("Value");
                    xAttribute.Value = ConvertToInvariantString(property);

                    // Add the value attribute to the key node
                    xKey.Attributes.SetNamedItem(xAttribute);

                    // Add the new key node to it's category node
                    xCategory.AppendChild(xKey);
                } else {
                    // Set the new key value to existing key node
                    xKey.Attributes["Value"].Value = ConvertToInvariantString(property);
                }
            }

            // Load the XSL stylesheet for XML transformation
            XslCompiledTransform xslTransform = new XslCompiledTransform();
            xslTransform.Load(XmlReader.Create(new System.IO.StringReader(
                String.Format(Properties.Resources.XslSettings, xmlRootElement))));

            // Initialize and configure the XML writer settings
            XmlWriterSettings xmlSettings = new XmlWriterSettings() {
                Indent = true,
                IndentChars = "\t"
            };

            // Properly dispose of the XmlWriter object
            using(XmlWriter xWriter = XmlWriter.Create(xmlFilePath, xmlSettings)) {
                // Sort the XML file using the XSL stylesheet and save it
                lock(xWriter) {
                    xslTransform.Transform(xDocument, xWriter);
                }

                // Write a newline at end of file document
                xWriter.WriteRaw(Environment.NewLine);

                // Clear the XML writer buffer
                xWriter.Flush();
            }
        }

        #endregion

        #region Private Methods

        /*
         * Converts the specified property value to a culture-invariant string representation.
         */
        private string ConvertToInvariantString(PropertyInfo property) {
            // Get the type converter for the specified property
            TypeConverter typeConverter = TypeDescriptor.GetConverter(property.PropertyType);

            // Return a culture-invariant string from the property value
            return typeConverter.ConvertToInvariantString(property.GetValue(Data, null));
        }

        /*
         * Gets the dynamic default value matching the property name from the internal Defaults class.
         */
        private object GetDynamicDefaultValue(string propertyName) {
            // Get the Defaults nested type if it exists
            Type defaults = Data.GetType().GetNestedType("Defaults", BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Static);

            // Get the property specified by name
            PropertyInfo property = defaults.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Static);

            // Return the default value from the specified property
            return property.GetValue(null, null);
        }

        /*
         * Gets an array of all the internal properties of the current Data class.
         */
        private PropertyInfo[] GetProperties() {
            // Get the type of the Data class
            Type type = Data.GetType();

            // Return the list of internal properties
            return type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        }

        /*
         * Imports all the settings from the settings XML file.
         */
        private void ImportXmlFile() {
            object defaultValue;

            // Try to create a new XML document with the specified file path
            try {
                XmlTextReader xtr = new XmlTextReader(xmlFilePath);

                xDocument = new XmlDocument();
                xDocument.Load(xtr);

                xtr.Close();
            } catch {
                // Loop through all properties in the Data class
                foreach(PropertyInfo property in GetProperties()) {
                    // Search for the required setting attribute
                    EasySettingAttribute attribute = (EasySettingAttribute)Attribute.GetCustomAttribute(property,
                        typeof(EasySettingAttribute));

                    // Skip the current property if the setting attribute was not found
                    if(attribute == null) {
                        continue;
                    }

                    // Get the current property default value either if it's dynamic or not
                    if(attribute.DefaultValue == null) {
                        defaultValue = GetDynamicDefaultValue(property.Name);
                    } else {
                        defaultValue = attribute.DefaultValue;
                    }

                    // Set the current property value to the default one
                    SetProperty(property, null, defaultValue);
                }

                // Do not allow the values from the XML file to load
                return;
            }

            XmlNode xCategory, xKey;
            string xValue = null;

            // Loop through all properties in the Data class
            foreach(PropertyInfo property in GetProperties()) {
                // Search for the required setting attribute
                EasySettingAttribute attribute = (EasySettingAttribute)Attribute.GetCustomAttribute(property,
                    typeof(EasySettingAttribute));

                // Skip the current property if the setting attribute was not found
                if(attribute == null) {
                    continue;
                }

                // Select the XML node with the specified category name
                xCategory = xDocument.SelectSingleNode("//Category[@Name='" + attribute.CategoryName + "']");

                // Does the category node exist?
                if(xCategory != null) {
                    // Select the XML node with the specified key name
                    xKey = xCategory.SelectSingleNode("descendant::Key[@Name='" + property.Name + "']");

                    // Does the key node exist?
                    if(xKey != null) {
                        // Get the value from the specified category/key pair
                        xValue = xKey.Attributes["Value"].Value;

                        // Set the value to null if it's empty
                        if(xValue.Length <= 0) {
                            xValue = null;
                        }
                    }
                }

                // Get the current property default value either if it's dynamic or not
                if(attribute.DefaultValue == null) {
                    defaultValue = GetDynamicDefaultValue(property.Name);
                } else {
                    defaultValue = attribute.DefaultValue;
                }

                // Set the current property value to the new or default value
                SetProperty(property, xValue, defaultValue);

                // Reset the property default value and value to null
                defaultValue = null;
                xValue = null;
            }
        }

        /*
         * Import the settings from the XML file with the specified XML file path and root element.
         */
        private void InitializeSettings(string xmlFilePath, string xmlRootElement) {
            // Create a new instance of the type T
            Data = (T)Activator.CreateInstance<T>();

            // Is the XML root element valid?
            if(!Regex.Match(xmlRootElement, @"^[a-z_:][a-z0-9.-_:]+$", RegexOptions.IgnoreCase).Success) {
                throw new ArgumentException("The supplied root element is invalid according to the W3C " +
                    "recommendation for XML documents.", xmlRootElement);
            }

            // Set the XML file path and root element
            this.xmlFilePath = xmlFilePath;
            this.xmlRootElement = xmlRootElement;

            // Import the settings from the XML file
            ImportXmlFile();
        }

        /*
         * Sets the value of the specified property with a new value or the default value if invalid.
         */
        private void SetProperty(PropertyInfo property, object newValue, object defaultValue) {
            // Convert value if not null otherwise use default
            if(newValue != null) {
                // Get the property type code
                TypeCode typeCode = Type.GetTypeCode(property.PropertyType);

                // Removes the property type code if it's an enumeration
                if(property.PropertyType.IsEnum) {
                    typeCode = TypeCode.Empty;
                }

                // Convert the value to which type?
                switch(typeCode) {
                    case TypeCode.Boolean:
                        newValue = Convert.ToBoolean(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.Byte:
                        newValue = Convert.ToByte(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.SByte:
                        newValue = Convert.ToSByte(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.Char:
                        newValue = Convert.ToChar(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.Decimal:
                        newValue = Convert.ToDecimal(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.Double:
                        newValue = Convert.ToDouble(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.Single:
                        newValue = Convert.ToSingle(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.Int32:
                        newValue = Convert.ToInt32(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.UInt32:
                        newValue = Convert.ToUInt32(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.Int64:
                        newValue = Convert.ToInt64(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.UInt64:
                        newValue = Convert.ToUInt64(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.Int16:
                        newValue = Convert.ToInt16(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.UInt16:
                        newValue = Convert.ToUInt16(newValue, CultureInfo.InvariantCulture);
                        break;

                    case TypeCode.String:
                        newValue = Convert.ToString(newValue, CultureInfo.InvariantCulture);
                        break;

                    default:
                        TypeConverter typeConverter = TypeDescriptor.GetConverter(property.PropertyType);
                        newValue = typeConverter.ConvertFromInvariantString((string)newValue);
                        break;
                }
            } else {
                newValue = defaultValue;
            }

            // Set the specified property value to the new one
            property.SetValue(Data, newValue, null);
        }

        #endregion

    }

}
