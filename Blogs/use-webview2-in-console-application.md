---
author: Zhang Ran
date: 24-Dec-2023
taxonomies:
  - tags: ["C#", "WebView2", "Console Application"]
next: 
  text: 'Verify Git Commit'
  link: '/BLogs/verify-git-commit'
---

# Use WebView2 In Console Application

## What is WebView2

Check out the [introduction of WebView2](https://learn.microsoft.com/en-us/microsoft-edge/webview2/)

### Supported Programming Environments

According to the introduction, WebView2 is supported in the following programming environments:

- Win32 C/C++
- .NET Framework 4.5 or later
- .NET Core 3.1 or later
- .NET 5
- .NET 6
- WinUI 2.0
- WinUI 3.0

### Application in Console Application

WebView2 can be applied in WinForm, WPF, MAUI, etc., which have a UI.

Referring to this [issue](https://github.com/MicrosoftEdge/WebView2Feedback/issues/202). I found a way to approach it using message-only window.

There is an [article](https://devblogs.microsoft.com/oldnewthing/20171218-00/?p=97595) discussing the message-only window approach.

The strategy involves having a UI thread to trigger the WebView2 controller.

## Code snippets

#### **`.csproj`**

```xml
<Project Sdk="Microsoft.NET.Sdk">

 <PropertyGroup Label="Globals">
  <WebView2UseWinRT>False</WebView2UseWinRT>
 </PropertyGroup>

 <PropertyGroup>
  <OutputType>Exe</OutputType>
  <TargetFramework>net8.0-windows</TargetFramework>
  <UseWPF>true</UseWPF>
  <ImplicitUsings>enable</ImplicitUsings>
  <Nullable>enable</Nullable>
  <InvariantGlobalization>true</InvariantGlobalization>
  <SupportedOSPlatformVersion>7.0</SupportedOSPlatformVersion>
 </PropertyGroup>

 <ItemGroup>
  <PackageReference Include="Microsoft.Web.WebView2" Version="1.0.2210.55" />
  <PackageReference Include="WebView2.Runtime.X64" Version="120.0.2210.91" />
 </ItemGroup>

</Project>
```

#### **`program.cs`**

```csharp
using Microsoft.Web.WebView2.Core;
using System.IO;
using System.Windows.Threading;

namespace Demo;

internal class Program
{
    static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

    static void Main(string[] args)
    {
        var htmlContent = @"
<!doctype html>
<html>
  <head>
    <title>This is the title!</title>
  </head>
  <body>
    <p>Hello World</p>
  </body>
</html>
";
        // create a new thread
        var uiThread = new Thread((htmlContent) =>
        {
            Dispatcher.CurrentDispatcher.Invoke(async (string htmlContent) =>
            {
                // setup webview runtime
                var runtimePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebView2");
                var environment = await CoreWebView2Environment.CreateAsync(runtimePath, null, null);

                // create controller
                var browserController = await environment.CreateCoreWebView2ControllerAsync(HWND_MESSAGE);

                // create view
                var view = browserController.CoreWebView2;

                // load html content, could also use other methods to fetch request
                // html content is limited to 2 MB
                view.NavigateToString(htmlContent);

                // get html content body
                var response = await view.ExecuteScriptAsync("document.body.outerHTML");

                // print html content to pdf files, the file path should be full path, cannot use relative path
                await view.PrintToPdfAsync(@"D:\UseWebView2InConsoleApp\Demo\bin\Debug\net8.0-windows\hello.pdf");

                Console.WriteLine("Success!");
            }, 
            new object[] { htmlContent! });

            Dispatcher.Run();
        });

        uiThread.SetApartmentState(ApartmentState.STA); 
        uiThread.Start(htmlContent);
        uiThread.Join();
    }
}
```

## Limitation

1. WebView2 needs a UI thread to run. It seems it cannot use a Task to run the WebView2.

2. The `Dispatcher` is only available on Windows, making the method unavailable on Linux.

## other approaches

A popular library in JavaScript is Puppeteer. In C#, an alternative is [Puppeteer Sharp](https://www.puppeteersharp.com/).
