#region Copyright © 2008-2014 Ricardo Amaral

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
    public sealed class EasySettingsAttribute : Attribute {

        #region Private Fields

        private string categoryName;
        private object defaultValue;

        #endregion

        #region Internal Properties

        /*
         * The setting category name to use as XML node name.
         */
        internal string CategoryName {
            get {
                return categoryName;
            }
        }

        /*
         * The setting default value if none was available.
         */
        internal object DefaultValue {
            get {
                return defaultValue;
            }
        }

        #endregion

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Boolean" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingsAttribute(string categoryName, bool defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Byte" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingsAttribute(string categoryName, byte defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.SByte" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        [CLSCompliantAttribute(false)]
        public EasySettingsAttribute(string categoryName, sbyte defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Char" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingsAttribute(string categoryName, char defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Decimal" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingsAttribute(string categoryName, decimal defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Double" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingsAttribute(string categoryName, double defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Single" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingsAttribute(string categoryName, float defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Int32" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingsAttribute(string categoryName, int defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.UInt32" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        [CLSCompliantAttribute(false)]
        public EasySettingsAttribute(string categoryName, uint defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Int64" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingsAttribute(string categoryName, long defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.UInt64" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        [CLSCompliantAttribute(false)]
        public EasySettingsAttribute(string categoryName, ulong defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.Int16" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingsAttribute(string categoryName, short defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.UInt16" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        [CLSCompliantAttribute(false)]
        public EasySettingsAttribute(string categoryName, ushort defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and default value of <see cref="System.String" /> type.
        /// </summary>
        /// <param name="categoryName">The setting category name.</param>
        /// <param name="defaultValue">The setting default value.</param>
        public EasySettingsAttribute(string categoryName, string defaultValue) {
            this.categoryName = categoryName;
            this.defaultValue = defaultValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasySettingsAttribute" /> class with the specified category
        /// name and converting the specified default value of the specified value type using the invariant culture.
        /// </summary>
        public EasySettingsAttribute(String categoryName, Type valueType, object defaultValue) {
            this.categoryName = categoryName;

            // Convert default value from invariant string if not null or of enumerated type
            if(defaultValue != null && !valueType.IsEnum) {
                this.defaultValue = TypeDescriptor.GetConverter(valueType).ConvertFromInvariantString(
                    (string)defaultValue);
            } else {
                this.defaultValue = defaultValue;
            }
        }

        #endregion

    }

}
