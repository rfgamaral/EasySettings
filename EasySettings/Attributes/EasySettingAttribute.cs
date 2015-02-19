#region Copyright © 2008-2015 Ricardo Amaral

/*
 * Use of this source code is governed by an MIT-style license that can be found in the LICENSE file.
 */

#endregion

using System;
using System.ComponentModel;

namespace RA.Library.EasySettings {

    /// <summary>
    /// Specifies configuration options to implement on properties handled by <see cref="EasySettings" /> .
    /// </summary>
    [CLSCompliantAttribute(true)]
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class EasySettingAttribute : Attribute {

        #region Internal Properties

        /*
         * The setting category name to use as XML node name.
         */
        internal string CategoryName {
            get;
            private set;
        }

        /*
         * The setting default value if none was available.
         */
        internal object DefaultValue {
            get;
            private set;
        }

        /*
         * The setting value type for the specified value.
         */
        internal Type ValueType {
            get;
            private set;
        }

        #endregion

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Boolean" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingAttribute(string categoryName, bool defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(bool);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Byte" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingAttribute(string categoryName, byte defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(byte);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.SByte" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        [CLSCompliantAttribute(false)]
        public EasySettingAttribute(string categoryName, sbyte defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(sbyte);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Char" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingAttribute(string categoryName, char defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(char);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Decimal" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingAttribute(string categoryName, decimal defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(decimal);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Double" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingAttribute(string categoryName, double defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(double);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Single" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingAttribute(string categoryName, float defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(float);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Int32" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingAttribute(string categoryName, int defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(int);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.UInt32" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        [CLSCompliantAttribute(false)]
        public EasySettingAttribute(string categoryName, uint defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(uint);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Int64" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingAttribute(string categoryName, long defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(long);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.UInt64" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        [CLSCompliantAttribute(false)]
        public EasySettingAttribute(string categoryName, ulong defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(ulong);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Int16" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingAttribute(string categoryName, short defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(short);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.UInt16" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        [CLSCompliantAttribute(false)]
        public EasySettingAttribute(string categoryName, ushort defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(ushort);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and default value of <see cref="System.String" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingAttribute(string categoryName, string defaultValue) {
            CategoryName = categoryName;
            DefaultValue = defaultValue;
            ValueType = typeof(string);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and the specified value type with a dynamic default value.
        /// </summary>
        public EasySettingAttribute(string categoryName, Type valueType)
            : this(categoryName, valueType, null) {
            // No construction required
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingAttribute" /> class with the specified category
        /// name and converting the specified default value of the specified value type using the invariant culture.
        /// </summary>
        public EasySettingAttribute(string categoryName, Type valueType, object defaultValue) {
            CategoryName = categoryName;
            ValueType = valueType;

            // Return immediately if default value was not specified (defaults to dynamic default value)
            if(defaultValue == null) {
                return;
            }

            // Use the default value directly if it's of the same enumerated type as the property
            if(valueType.IsEnum) {
                if(defaultValue.GetType() != valueType) {
                    throw new ArgumentException(
                        "Default value must be of the same enumerated type as the property for enums.",
                        "defaultValue");
                }

                DefaultValue = defaultValue;

                return;
            }

            // Use a native type converter to convert the default value from an invariant string
            DefaultValue = TypeDescriptor.GetConverter(valueType).ConvertFromInvariantString((string)defaultValue);
        }

        #endregion

    }

}
