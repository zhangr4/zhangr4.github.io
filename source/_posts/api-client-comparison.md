---
title: Comparing Web API Client Development Stacks(C#)
author: Zhangr4
date: 2024-Dec-30
tags:
  - Web Api Client
  - Kiota
  - Refit
  - Flurl
  - RestSharp
  - HttpClient
  - C#
---

When developing web API clients, especially for in C#. There are few popular options as far I can see: Kiota, Refit, Flurl, and RestSharp.

<!-- more -->

## Tech stack options

### Kiota

[Kiota](https://github.com/microsoft/kiota) is a code generator that creates API clients from OpenAPI descriptions. It supports multiple programming languages and aims to provide a consistent and type-safe way to interact with APIs.

Its primary purpose is to automatically generate API clients, which accelerates development but can also limit flexibility.

Pros:

- **Type Safety**: Generates strongly-typed clients, reducing runtime errors.
- **Multi-language Support**: Can generate clients for various languages.
- **Consistency**: Ensures a uniform approach to API consumption.

Cons:

- **Learning Curve**: Requires understanding of OpenAPI and the Kiota toolchain.
- **Setup**: Initial setup can be time-consuming.
- **Strict OpenAPI Definition**: The OpenAPI documentation must be precise and accurate.

### Refit

[Refit](https://github.com/reactiveui/refit) is a library for .NET that turns REST APIs into live interfaces. It uses attributes to define API endpoints and automatically generates the necessary code to call them.

Within the library, it uses source generator to generate interface implementation.

With [Refitter](https://github.com/christianhelle/refitter), C# REST API Client could be auto generated.

Pros:

- **Simplicity**: Easy to use with minimal boilerplate code.
- **Integration**: Seamlessly integrates with .NET projects.
- **Maintainability**: Changes to API endpoints are easy to manage.

Cons:

- **Limited to .NET**: Only available for .NET languages.
- **Performance**: May have overhead due to reflection.

### Flurl

[Flurl](https://github.com/tmenier/Flurl) is a modern, fluent, asynchronous, testable, and portable URL builder and HTTP client library for .NET. It simplifies making HTTP calls and handling URLs in a clean and readable way.

Pros:

- **Ease of Use**: Provides a fluent interface for building URLs and making HTTP requests.
- **Asynchronous**: Fully supports async/await for non-blocking operations.
- **Testable**: Designed with testability in mind, making it easy to mock HTTP calls.
- **Portable**: Works across different .NET platforms, including .NET Core and .NET Framework.

Cons:

- **Learning Curve**: May require some time to get familiar with its fluent syntax.
- **Dependency**: Adds an additional dependency to your project.

### RestSharp

[RestSharp](https://github.com/restsharp/RestSharp) is a popular library for building API clients in .NET. It provides a simple and flexible way to interact with RESTful services.

Pros:

- **Feature-Rich**: Supports a wide range of features like authentication, serialization, and more.
- **Community Support**: Large user base and active community.
- **Flexibility**: Can be used for simple and complex scenarios.

Cons:

- **Complexity**: Can be overkill for simple APIs.
- **Performance**: May have performance overhead in some cases.

## Popularity

Until 30-Dec-2024, the github repo stars as shown below:

| Library   | Repository          | Stars |
| --------- | ------------------- | ----- |
| RestSharp | restsharp/RestSharp | 9651  |
| Refit     | reactiveui/refit    | 8723  |
| Flurl     | tmenier/Flurl       | 4246  |
| Kiota     | Microsoft/kiota     | 3081  |

## Maintainability

### Code and Generated API Client Structure
This section evaluates how uniformly the code and generated API clients are structured across different API definitions for each library.

- **Kiota**: Uniform structure due to OpenAPI-based code generation.
- **Refit**: Consistent structure if interfaces are defined uniformly.
- **RestSharp**: No uniform structure; varies with manual implementation.
- **Flurl**: No uniform structure; varies with dynamic request construction.

### Official Documentation
This section assesses the quality and comprehensiveness of the official documentation provided by each library.

- **Kiota**: Comprehensive, covering setup, usage, and advanced scenarios. Troubleshooting guides available.
- **Refit**: Well-documented with clear examples and explanations for setup, usage, and advanced scenarios. Troubleshooting information available.
- **RestSharp**: Good documentation, but can be less detailed in some areas. Covers setup and usage well, but advanced scenarios and troubleshooting might require more community support.
- **Flurl**: Thorough documentation with detailed guides on setup, usage, and advanced scenarios. Troubleshooting information provided.

### Update Frequency
This section examines how frequently each library receives updates, including recent commits and releases.

- **Kiota**: High commit and release frequency, with multiple commits and releases in December 2024.
- **Refit**: High commit frequency, with several commits and releases in the last few months of 2024.
- **RestSharp**: Frequent commits and releases, with recent activity extending into early January 2025.
- **Flurl**: Frequent commits and releases, with recent activity extending into early January 2025.

### Licensing and Compliance
This section reviews the licensing and compliance aspects of each library.

- **Kiota**: MIT License (typically used by Microsoft projects)
- **Refit**: MIT License
- **RestSharp**: Apache 2.0 License
- **Flurl**: MIT License

All these licenses are permissive and generally allow for use in enterprise commercial projects.

### Learning Curve
This section evaluates the learning curve associated with each library.

- **Refit**: Easiest to learn due to its simplicity, excellent documentation, and active community support.
- **RestSharp**: Easy to learn with comprehensive documentation and active community support. Slightly more complex due to broader feature set.
- **Flurl**: Relatively easy to learn with a fluent API that simplifies HTTP requests. Slightly steeper learning curve compared to Refit and RestSharp due to its unique approach.
- **Kiota**: Hardest to learn due to its complexity as a code generator and the additional steps required to understand and use the generated code. More suitable for advanced users.

### Maintainability comparison
| Aspect              | Kiota         | Refit      | RestSharp  | Flurl    |
| ------------------- | ------------- | ---------- | ---------- | -------- |
| **Code Structure**  | Uniform       | Consistent | Varies     | Varies   |
| **Documentation**   | Comprehensive | Excellent  | Good       | Detailed |
| **Update Frequency**| High          | High       | Frequent   | Frequent |
| **License**         | MIT           | MIT        | Apache 2.0 | MIT      |
| **Learning Curve**  | Hard          | Easy       | Easy       | Moderate |

## Performance

I created a simple benchmarking to compare these different stacks, refer to [ApiClientComparison](https://github.com/zhangr4/Playground/tree/main/Zhangr4.PlaygroundDotNet/Zhangr4.Playground.ApiComparison.ClientBenchmark)

Spec: BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2605). 
AMD Ryzen 5 3550H with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores

- Host: .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2

  | Method              | Mean     | Error   | StdDev   | Median   | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
  |-------------------- |---------:|--------:|---------:|---------:|------:|--------:|--------:|----------:|------------:|
  | HttpClient_Run      | 281.8 μs | 5.63 μs | 10.99 μs | 279.6 μs |  1.00 |    0.05 |  1.9531 |   4.01 KB |        1.00 |
  | KiotaClient_Run     | 417.6 μs | 8.28 μs | 22.37 μs | 406.2 μs |  1.48 |    0.10 | 10.7422 |  22.64 KB |        5.65 |
  | RefitClient_Run     | 251.0 μs | 3.49 μs |  3.09 μs | 250.1 μs |  0.89 |    0.04 |  2.9297 |   6.11 KB |        1.52 |
  | FlurlClient_Run     | 271.5 μs | 2.97 μs |  2.48 μs | 271.1 μs |  0.96 |    0.04 |  6.3477 |  13.25 KB |        3.31 |
  | RestSharpClient_Run | 303.3 μs | 4.17 μs |  3.48 μs | 303.0 μs |  1.08 |    0.04 | 19.5313 |   36.1 KB |        9.01 |

- Host: .NET Framework 4.8.1 (4.8.9290.0), X64 RyuJIT VectorSize=256

  | Method              | Mean     | Error   | StdDev   | Median   | Ratio | RatioSD | Gen0    | Allocated | Alloc Ratio |
  |-------------------- |---------:|--------:|---------:|---------:|------:|--------:|--------:|----------:|------------:|
  | HttpClient_Run      | 391.7 us | 8.25 us | 23.53 us | 386.3 us |  1.00 |    0.08 |  7.3242 |  15.95 KB |        1.00 |
  | KiotaClient_Run     |       NA |      NA |       NA |       NA |     ? |       ? |      NA |        NA |           ? |
  | RefitClient_Run     | 445.0 us | 9.93 us | 28.48 us | 444.3 us |  1.14 |    0.10 |  8.7891 |  18.96 KB |        1.19 |
  | FlurlClient_Run     | 426.6 us | 8.92 us | 25.29 us | 418.2 us |  1.09 |    0.09 | 14.6484 |  31.31 KB |        1.96 |
  | RestSharpClient_Run | 518.3 us | 5.67 us |  4.73 us | 518.0 us |  1.33 |    0.08 | 27.3438 |   57.6 KB |        3.61 |

The performance benchmarking results should be interpreted with caution. They do not fully represent real-world scenarios, as network connectivity often plays a more significant role.

## Summary

### Shared Features
Despite their differences, Kiota, Refit, RestSharp, and Flurl share several common features that make them popular choices for developing web API clients:

- **HTTP Client Abstraction**: Simplifies making HTTP requests.
- **Asynchronous Support**: Allows for non-blocking HTTP calls.
- **Serialization/Deserialization**: Built-in support using popular libraries like JSON.NET.
- **Error Handling**: Mechanisms to handle HTTP errors and exceptions gracefully.
- **Configuration**: Options to configure headers, query parameters, and other request settings.
- **Authentication**: Support for various methods like OAuth, API keys, and basic authentication.
- **Extensibility**: Ability to extend and customize behavior through middleware, handlers, or plugins.
- **Dependency Injection**: Integration with dependency injection frameworks.

### Target Use Scenarios

- **Kiota** is specialized for generating API clients from OpenAPI descriptions, making it ideal for projects requiring consistent API consumption.
- **Refit** provides a type-safe, attribute-based approach to creating REST clients, reducing boilerplate code for .NET developers.
- **RestSharp** offers a comprehensive solution for making HTTP requests with extensive configuration options, suitable for complex interactions with RESTful services.
- **Flurl** emphasizes simplicity and readability with a fluent interface, making it a good choice for developers who prefer chaining requests and asynchronous operations.

___

Disclaimer: This blog post was partially created using GitHub Copilot for efficiency and content generation.