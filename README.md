# EasySettings

Simple .NET library to easily manage applications user preferences.

This library was built to be as easy and straightforward to use by simply placing all the application settings as properties in a single class file; keeping your code base clean and allowing conditional logic within the properties getter and setter methods. All the settings values will be stored in an XML file for easy reading and manual modification.

## Features

 - Automatically load all settings from an XML file into a specified class.
 - Direct settings access through any property in the `Data` object.
 - Fallback to default values if the XML settings file does not exist.
 - Use attributes to define the setting category and default value.
 - Supports both static and dynamic default values for any type.
 - Supports all simple types and any type supported by `TypeConverter`.
 - Sorts both the categories and keys in the XML file alphabetically.
 - Save all application settings by calling a single method.

## Download

Please refer to the [releases](https://github.com/rfgamaral/EasySettings/releases) page to downloaded the binaries for the latest release.

## Usage Guide

Please refer to the documentation on the [wiki](https://github.com/rfgamaral/EasySettings/wiki) to learn more about how to use EasySettings.

## Changelog

Please refer to the [CHANGELOG](CHANGELOG.md) file for the full changelog details.

## Thanks

  - [Stan Schultes](https://www.linkedin.com/in/stanschultes) for his XML parser library which helped me understand how to work with XML files.
  - Betovsky from the [Portugal-a-Programar](http://www.portugal-a-programar.pt) forum for some implementation ideas and generics help.
  - KeeperOfTheSoul from the IRC Freenode network for helping me with XSL transformations.

## License

Use of this source code is governed by an MIT-style license that can be found in the [LICENSE](LICENSE) file.
