# C# Challenge

Challenge Description: Assume that you are given a JSON file containing the results of an executed test case. Your task is to create a C# program that processes this JSON data, converts it into a CSV file format, exports it, and generates various metrics based on the test results.

## Prerequisites
- [Visual Studio Code](https://code.visualstudio.com)
- [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [The .NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).

For information about how to install extensions on Visual Studio Code, see [VS Code Extension Marketplace](https://code.visualstudio.com/docs/editor/extension-marketplace).

## Dependencies
- CsvHelper Version="30.0.1"
- HtmlAgilityPack Version="1.11.54"
- Newtonsoft.Json Version="13.0.3

**Notes:** if you have any kind of issue running this project please run **dotnet add package [name of the package] --version [version]**

## Features

- Parse JSON data into C# objects.
- Create and export CSV and HTML files.
- Calculate and display relevant metrics accurately.
  
## Run
- Clone the project
- Open VsCode
- Open the folder containing the project
- Run dotnet run in the terminal
- Results should be printed in the console
- Resuts should be exported in the output folder as: "test_results.csv" and "test_results.html"

  **Notes:** test_results.html is an additional feature to export metrics of any execution to allow future implementation of charts, emailable report in HTML format



