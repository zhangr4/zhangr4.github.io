---
title: Exploring the Scenarios and Limitations of Roslyn Source Generators
author: Zhangr4
date: 2024-Dec-30
tags: 
  - Source Generator
  - C#
  - Roslyn    
---

The Roslyn API empowers developers with compile-time metaprogramming through [source generator](https://learn.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/#source-generators), which can produce C# code and additional files during the compilation process. This blog post delves into the various scenarios where source generators can be applied and highlights their limitations.

### Understanding Source Generators

A source file typically refers to a text file containing C# source code that is generated during compilation. The Roslyn API's source generators can automate this process, making development more efficient.

### 3 Scenarios

The following scenarios are discussed in the [issue](https://github.com/dotnet/roslyn/issues/57608):

- Source to Source

    This is the most straightforward use case: generating C# code based on existing C# code. Source generators are designed for this purpose. Examples include generating boilerplate code, implementing interfaces, or creating DTOs (Data Transfer Objects) from annotated classes.

- Non-source to Source

    This scenario involves converting non-C# sources, such as XML or C++, into C# code. It is useful for generating C# classes from configuration files, schemas, or other non-C# sources. For example, generating C# classes from an XML schema (XSD) ensures type safety and reduces manual coding.

- Source to Non-source

    This scenario involves converting C# code into non-C# artifacts, such as JSON or XML files. It is useful for generating configuration files, documentation, or other artifacts that are not C# code. A well-known use case is generating OpenAPI/Swagger documentation. Currently, Swagger/OpenAPI documentation is generated at runtime when the program starts.

### Limitations of Source Generators

Despite their powerful capabilities, source generators have some limitations:

1. **Compile-time Documentation Generation**: Generating documentation (e.g., Swagger/OpenAPI) at compile time rather than runtime. Source generators currently do not support this capability.

2. **Resource File Generation**: Generating resource files (e.g., images, binary files) from C# code at compile time. This would be useful for embedding resources directly into the assembly, but it is not currently supported by source generators.

### Alternative Solutions

While source generators have their limitations, there are alternative solutions that can be used to achieve similar goals:

- **Custom MSBuild Tasks**: Custom MSBuild tasks can be created to perform actions during the build process. This can include generating code, resources, or documentation. By integrating custom tasks into the build pipeline, developers can achieve compile-time generation of artifacts that are not supported by source generators.

- **Workaround with Comment Source**: In some cases, developers can use comments within the source code to provide metadata or instructions for generating additional code or resources. Tools can then parse these comments and generate the necessary artifacts. This approach can be useful for scenarios where source generators fall short, but it requires additional tooling and conventions to be effective.

### Summary

Roslyn source generators offer powerful capabilities for compile-time metaprogramming, enabling the generation of C# code and additional files during the compilation process. However, they have limitations, such as the inability to generate documentation or resource files at compile time. Alternative solutions, like custom MSBuild tasks, pre-build/post-build scripts, and third-party tools, can help address these gaps. Understanding these limitations and exploring potential future enhancements can help developers effectively leverage source generators in their projects.

___

Disclaimer: This blog post was partially created using GitHub Copilot for efficiency and content generation.
