# lesson learn from restapi course

1. 分层架构

    - api层，统一的api管理，日志，健康检查等等

    - 应用层，同一个业务出口，可以供上层api层，也可以提供其他的交互层，例如GRPC, Blazor等等

2. 提供的request和response contract

request 和 response contract中的属性在c#11(.Net7)之后可以使用`required`关键字，并且写成`{get; init;}`

3. 使用扩展函数进行依赖注入，这样上层无需知道下层的内容

4. controller actionresult返回created("the resource path", the resource instance)
使用`CreatedAtAction(nameof(get), new { id = movie }, movie)`


5. automapper还是挺好用的，也可以用扩展函数手动mapping


6. 防止在route中使用magic string的方法

构建静态类

```csharp
public static class ApiEndpoints
{
    private static readonly string ApiBase = "api"

    private static class Movie
    {
        private static readonly string Base = $"{ApiBase}/Movie";

        public static readonly string Create = Base;
    }
}
```

7. 如果resource的id是guid，可以用slug作为alternative id

8. [use source generator for regex](https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-source-generators?pivots=dotnet-8-0)

9. 多层验证，api层验证contract，业务层验证业务数据，可以使用fluentvalidation

10. HAL, hypermedia api language

11. api versioning 

12 swagger

13. health check

14. api response caching(client side)

15. api output caching(server side)

16. apikey auth

17. use refit to create api sdk

领域驱动设计

1. 理念之一，用数量简化关系，对于不同的业务，即使部分或者全部代码可以复用，也不要复用，分开来，这样的话不同业务之间完全独立

2. Entity实体

- 具有identity