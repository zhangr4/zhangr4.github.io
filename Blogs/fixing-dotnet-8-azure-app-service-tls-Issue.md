---
author: Zhang Ran
date: 16-Jun-2023
taxonomies:
  - tags: [".NET 8", "Azure App Service", "TLSv1.3", "TLSv1.2"]
prev: 
  text: 'Introduction of Time-based One-time password(TOTP)'
  link: '/BLogs/time-based-one-time-password'
---

# Overcoming Network Connection Issues in .NET 8: A Troubleshooting Journey

## Introduction

In my latest project, I encountered a puzzling issue while deploying a .NET 8 application to Azure App Service. Despite working flawlessly on Windows, the application failed when deployed to the Azure App Service for Linux. This post details the steps I took to diagnose and resolve the problem, offering insights that might help others facing similar challenges.

## Description

I have an application using .NET 8 with a dependency that connects to a specific server. This dependency, written in Delphi, is not open-sourced; I only have the .dll files. The server's URI uses HTTPS, but I have no control over the server itself.

When running my application on Windows, it works fine. However, when I deployed it to Azure App Service for Linux, it failed. Additionally, running the application using a default .NET Docker image ([mcr.microsoft.com/dotnet/runtime:8.0](https://hub.docker.com/_/microsoft-dotnet-runtime/)) resulted in a "404 not found" error. This confused me because the URI works perfectly fine in a browser, Postman, Curl, etc.

## Troubleshooting Steps

### Identifying the Difference

The key difference seemed to be the environment: one using Windows, the other using the default .NET Docker image.

### Decompiling the .dll

I decompiled the .dll file and traced the error to the line of code responsible for creating the HTTP channel.

### Discovering the Breaking Change

After some research, I discovered a [breaking change since .NET 5 for Linux](https://learn.microsoft.com/en-us/dotnet/core/compatibility/cryptography/5.0/default-cipher-suites-for-tls-on-linux). This change indicated:

> Starting in .NET 5, .NET on Linux respects the OpenSSL configuration for default cipher suites when it's specified in openssl.cnf. When cipher suites aren't explicitly configured, the only permitted cipher suites are as follows:
> - TLS 1.3 cipher suites
> - TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384
> - TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256
> - TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384
> - TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256
> - TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384
> - TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256
> - TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384
> - TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256

### Verifying the Server's TLS Support

Using sslscan, I found that the server only supports TLSv1.2.

### Understanding Azure App Service for Linux

I also learned that Azure App Service for Linux creates a container behind the scenes.

## Fix

Here are a few potential solutions:

1. **Contact the Server Operator**: Ask if they can update the supported TLS version.
2. **Customize the Docker Image**: Create a Dockerfile with a custom openssl.cnf file, as detailed in this [Stack Overflow post](https://stackoverflow.com/a/66901574/16274628).

## Conclusion

This troubleshooting journey highlighted the importance of understanding environmental differences and the impact of breaking changes. By systematically diagnosing the issue, I was able to identify a suitable solution. If you encounter similar issues, consider these steps and don't hesitate to reach out for support or share your experiences in the comments below.
