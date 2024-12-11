# Core Tool Kit

![License](https://img.shields.io/github/license/Palanx/core-tool-kit)
![Issues](https://img.shields.io/github/issues/Palanx/core-tool-kit)
![Stars](https://img.shields.io/github/stars/Palanx/core-tool-kit)
![Forks](https://img.shields.io/github/forks/Palanx/core-tool-kit)

The **Core Tool Kit** is a versatile and modular toolset designed to enhance the functionality of your projects by providing a collection of utilities, extensions, and tools. It is developed with a focus on usability, efficiency, and ease of integration into various projects.

## Table of Contents

- [Core Tool Kit](#core-tool-kit)
  - [Table of Contents](#table-of-contents)
  - [Installation](#installation)
    - [Clone the Repository](#clone-the-repository)
    - [Add as a Submodule](#add-as-a-submodule)
    - [Package Manager](#package-manager)
  - [Features](#features)
  - [Usage](#usage)
    - [Example](#example)
  - [Documentation](#documentation)
  - [Contributing](#contributing)
  - [License](#license)

## Installation

You can install the Core Tool Kit using the following methods:

### Clone the Repository

```bash
git clone https://github.com/Palanx/core-tool-kit.git
```

### Add as a Submodule

If you are integrating this into an existing repository:

```bash
git submodule add https://github.com/Palanx/core-tool-kit.git core-tool-kit
```

### Package Manager

> (If published on a package manager like npm, NuGet, or Unity Package Manager, include the installation instructions here)

## Features

- **Utilities**: A collection of commonly used functions to simplify complex tasks.
- **Extensions**: Extend the capabilities of existing classes, adding new methods and functionality.
- **Tools**: Various standalone tools to aid in project development and debugging.
- **Modular Design**: Easily include only the components you need.

## Usage

After installing the Core Tool Kit, you can start using it in your project by importing the necessary components:

```csharp
using CoreToolKit.Utilities;
using CoreToolKit.Extensions;
```

### Example

Here is a simple example demonstrating how to use one of the utility methods:

```csharp
var result = StringUtilities.Reverse("Hello World!");
Console.WriteLine(result); // Output: !dlroW olleH
```

> Feel free to explore the `Examples` directory in the repository for more use cases and practical applications.

## Documentation

Comprehensive documentation is available [here](https://github.com/Palanx/core-tool-kit/wiki) or can be generated using [DocFX](https://dotnet.github.io/docfx/) if included in the repository. The documentation provides detailed information about each feature, method, and tool provided by the Core Tool Kit.

## Contributing

We welcome contributions from the community! Here's how you can get involved:

1. Fork the repository
2. Create a new branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Create a new Pull Request

Please ensure all contributions adhere to our [Code of Conduct](https://github.com/Palanx/core-tool-kit/blob/main/CODE_OF_CONDUCT.md) and follow the [Contribution Guidelines](https://github.com/Palanx/core-tool-kit/blob/main/CONTRIBUTING.md).

## License

This project is licensed under the GPL-3.0 - see the [LICENSE](LICENSE) file for details.

---

Made with ❤️ by [Palanx](https://github.com/Palanx)