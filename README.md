# Core Tool Kit

![License](https://img.shields.io/github/license/Palanx/core-tool-kit)
![Issues](https://img.shields.io/github/issues/Palanx/core-tool-kit)
![Stars](https://img.shields.io/github/stars/Palanx/core-tool-kit)
![Forks](https://img.shields.io/github/forks/Palanx/core-tool-kit)

The Core Tool Kit is a versatile and modular toolset designed to enhance the functionality of your Unity projects by
providing a curated collection of utilities, extensions, and tools. Focused on reliability, performance, and ease of
use, this package aims to simplify common development tasks and improve code quality across various game development
scenarios.

---

## Table of Contents

<!-- TOC -->
* [Core Tool Kit](#core-tool-kit)
  * [Table of Contents](#table-of-contents)
  * [Import the Package](#import-the-package)
    * [Unity Package Manager](#unity-package-manager)
      * [Current `main` version](#current-main-version)
      * [Tags](#tags)
      * [Releases](#releases)
    * [Package Dependencies](#package-dependencies)
      * [TextMeshPro](#textmeshpro)
      * [DoTween](#dotween)
  * [Modules](#modules)
  * [Tests](#tests)
  * [Documentation](#documentation)
  * [Contributing](#contributing)
  * [License](#license)
<!-- TOC -->

---

## Import the Package

### Unity Package Manager

#### Current `main` version

To import the current version from `main` branch, add the package using the next Git URL:
```
https://github.com/Palanx/core-tool-kit.git?path=/Packages/net.palanx.core-tool-kit
```

#### Tags

To import a specific [Tag](https://github.com/Palanx/core-tool-kit/tags), add the package using the next Git URL:
```
https://github.com/Palanx/core-tool-kit.git?path=/Packages/net.palanx.core-tool-kit#{version-tag}
```

#### Releases

Import a Release of this package as an *embedded* package is a good idea when you want to:
- Edit the package's contents directly inside the Unity project, which is helpful for iterative development or when
debugging package code.
- Include the package in the project folder, so it can be shared with the team, added to version control, or
archived without worrying about external dependencies.
- Become the package part of the project's version control. This ensures that everyone working on the
project uses the exact same version of the package.

but, you should know that it will always be better to create a fork of the package to be able to modify it because:
- Without a central repository, managing versions and distributing updates can become cumbersome.
- The package is editable within the project, there’s a risk of accidental changes that may break its functionality.
- The package code becomes tightly coupled with the project, which may not be ideal if you plan to reuse the package in multiple projects.
- If the package is used in multiple projects, you'll need to manually update the package in each project when changes are made.

To import a specific [Release](https://github.com/Palanx/core-tool-kit/releases):
1. Download the `net.palanx.core-tool-kit-{version-tag}.zip` file of the release version tag that you want to include.
2. Decompress the file and move the `net.palanx.core-tool-kit-{version-tag}` folder into the `\Packages\` folder.
3. Unity will automatically recognize the *embedded* package.


### Package Dependencies

This package has the next dependencies:

- TextMeshPro
- DoTween

So they must be imported in the project where this package was imported:

#### TextMeshPro

1. Go to the toolbar and press `Edit -> Project Settings...`.
2. In the `TextMeshPro` tab, press the `Import TMP Essentials`.
3. Done.

#### DoTween

1. Open this [DoTween Package URL](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676), and
add it to your Unity account, in the case you don't have the
[DoTweenPro](https://assetstore.unity.com/packages/tools/visual-scripting/dotween-pro-32416) version, if you have the
Pro version, use it instead of the standard version.
2. Go to the toolbar and press `Windows -> Package Manager`.
3. In the `My Assets` section look for the *DOTween* package, or *DoTweenPro* if you bought it, and import it into the
project.
4. A modal will appears, press the `Setup DoTween...` button to config the package that you already installed.
5. Done.

---

## Modules

``` 
Modules/
│
├── Logger/
│   ├── LogManager // Manager that handles Logger instances for specific types.
│   └── Logger // Logger for a specific type.
│
├── NET_System/
│   ├── Delegate/
│   │   └── Extensions/
│   │       └──DelegateExtensions // Method extensions for delegates.
│   └── Threading/
│       └── Extensions/
│           └──TaskExtensions // Method extensions for Task.
│
├── TextMeshPro/
│   └── Extensions/
│       └── TMP_TextExtensions // Method extensions for TMP_Text.
│
└──UnityEngine/
   ├── Attributes/
   │   └── ReadOnlyInspectorAttribute // Attribute to make readonly a serialized field in the Inspector.
   ├── Extensions/
   │   ├── RectExtensions // Method extensions for Rect.
   │   ├── RectTransformExtensions // Method extensions for RectTransform. Transformations to (World <──> Screen) Space included.
   │   └── VectorExtensions // // Method extensions for Vector2 and Vector3.
   ├── Scheduler/
   │   └── UnityTaskRunner // Provides a mechanism to schedule threads against Unity's UnitySynchronizationContext.
   └── UI/
       ├── TypewriterEffect // Component that display text in a TMPro.TMP_Text component.
       └── Utils/
           └── DisplayFormatUtils // Utils class to format values.
```

---

## Tests

Under the path `\Assets\Tests\` you'll find the `EditorMode` and `PlayMode`, those folders have the test for the
previous listed `Modules`, using the same folder structure.

> [!IMPORTANT]
> The `PlayMode` tests aren't already made because I don't feel like doing it for now, I have no time and something
> that I really hate to do is `PlayMode` tests 🫠 BUT! some day I'll include them.

---

## Documentation

There isn't documentation, each module is self explained and easy to use for a developer with C# experience.

---

## Contributing

I welcome contributions from the community! Here's how you can get involved:

1. Fork the repository
2. Create a new branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Create a new Pull Request

It is very likely that it does not merge third-party PRs, because I always filter that all code written follows the
same line as the package, and it is very common that game developers write bad code, but come up with very good ideas,
so I almost always take that idea and refactor it.

---

## License

This project is licensed under the GPL-3.0 - see the [LICENSE](LICENSE) file for details.

---

Made with ❤️ by [Palanx](https://github.com/Palanx)