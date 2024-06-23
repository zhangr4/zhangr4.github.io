---
author: Zhang Ran
date: 23-Jun-2024
taxonomies:
  - tags: ["Git", "Versioning"]
prev: 
  text: 'Fixing .NET 8 Azure App Service TLS Issue'
  link: '/Blogs/fixing-dotnet-8-azure-app-service-tls-Issue'

---

# 利用GitVersion对.NET项目版本控制

最早在初学C#的时候有接触过一点点GitVersion，但它的Configuration过于繁杂，当时对C#也不是很了解，尤其是对Assembly，文件结构，构建，编译项目相关内容。所以看过Demo也就忘了。这次参考相关文章和官网的文档进行尝试。

## 工具和环境

- IDE: Visual Studio 2022
- .NET Runtime: .Net 8
- GitVersion: gitversion.tool 6.0.0-rc.1

## 试验过程

### 安装GitVersion

采用dotnet cli安装，命令行`dotnet tool install --global GitVersion.Tool --version 6.0.0-rc.1`，因为是安装最新的prerelease，指定了版本号。命令行参考[Nuget](https://www.nuget.org/packages/GitVersion.Tool/6.0.0-rc.1)。并且采用了全局安装。

### 创建控制台应用

用Visual Studio创建控制台应用。

### 初始化Git

在Visual Studio中初始化Git，参考[Create a Git repository from Visual Studio](https://learn.microsoft.com/en-us/visualstudio/version-control/git-create-repository?view=vs-2022)

### .Net项目版本控制

.Net中关于程序集Assembly一般有三个版本信息

- Assembly Version 对应该程序集的版本，运行时加载Assembly时会读取该版本号。

- Assembly File Version，对应程序集文件版本号，通常在文件属性中能看到文件版本号。

- AssemblyInformationalVersion，对应程序集版本信息，通常用于产品的版本。

### 生成AssemblyInfo.cs

.Net项目创建时会默认在Build时生成程序集信息，需要在项目属性中取消勾选Generate AssemblyInfo。或者在.csproj文件中Property Group中添加`<GenerateAssemblyInfo>False</GenerateAssemblyInfo>`。这样Build时就不会自动生成AssemblyInfo.cs文件。

![取消勾选Generate AssemblyInfo](/gitversion_project_property.png)

AssemblyInfo.cs文件一般位于Property文件下。Properties文件夹在初始时是没有的，需要新建。如果是ASP.NET项目，Properties文件下会有launch profile。

我们需要让GitVersion生成AssemblyInfo.cs，命令:

``` ps1
dotnet-gitversion /updateassemblyinfo Properties\AssemblyInfo.cs /ensureassemblyinfo
```

`/updateassemblyinfo`是更新程序集信息，`/ensureassemblyinfo`是确保程序集信息存在。

官方文档中使用`GitVersion.exe`,如果是使用dotnet tool安装，需要将`GitVersion.exe`替换成`dotnet-gitversion`。

这样就会生成程序集信息。

### 每次Build时更新程序集信息

添加pre build事件在每次build时更新程序集信息。

```ps1
dotnet-gitversion /updateassemblyinfo $(ProjectDir)Properties\AssemblyInfo.cs /ensureassemblyinfo
```

![添加预编译事件](/gitversion_prebuild_event.png)

### 更新GitVersion配置文件

在proj目录下手动添加`GitVersion.yml`，也可以参考官方文档中`init`命令生成配置文件。

需要注意的是，*23-Jun-2024*官方文档还没有为6.0-rc1更新，文档中的部分配置项在6.0-rc1中貌似不支持。需要去除相应的配置项。

## 参考

[GitVersion](https://github.com/GitTools/GitVersion)

[GitVersion Docs](https://gitversion.net/docs/)

[VS中实现软件版本号自增](https://www.bilibili.com/video/BV1kx4y1b7vV/?spm_id_from=333.1007.top_right_bar_window_history.content.click&vd_source=512e802b6f501a7cb1aaad55de9f9067)

[对项目版本自动控制——利用gitversion](https://www.cnblogs.com/JerryMouseLi/p/14366880.html)