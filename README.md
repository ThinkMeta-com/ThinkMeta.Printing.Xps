# ThinkMeta.Printing.Xps

[![NuGet Package](https://img.shields.io/nuget/v/ThinkMeta.Printing.Xps)](https://www.nuget.org/packages/ThinkMeta.Printing.Xps)

XPS printing routines for .NET 8, .NET 9, and .NET 10 (Windows only).

## Features
- Print XPS files to any installed Windows printer
- Optional support for custom printer settings via DEVMODE
- Simple API for integration in .NET desktop or server applications

## Usage Example

```csharp
using ThinkMeta.Printing.Xps;

XpsPrinter.Print(@"C:\\path\\to\\file.xps", "Your Printer Name");
```

## Requirements
- Windows OS
- .NET 8, .NET 9, or .NET 10 (Windows)

## Installation
Add the NuGet package to your project:

```
dotnet add package ThinkMeta.Printing.Xps
```

## License
MIT License. See LICENSE file for details.

## Project Links
- [GitHub Repository](https://github.com/ThinkMeta-com/ThinkMeta.Printing.Xps)
