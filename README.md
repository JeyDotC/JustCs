# JustCs

Forget about templating, use just C#!

Create your page:

```csharp
public class MyPage : ComponentElement
{
    protected override Element Render(IElementAttributes props) =>
        _<Html>(
            _<Head>(
                _<Title>("Hello World")
            ),
            _<Body>(
                _<H1>("Hello from JustCs!")
            )
        );
}
```

Serve your page:

```csharp
[ApiController]
[Route("[controller]")]
public class MyPageController : ControllerBase
{
    [HttpGet]
    public IView Index() => new View<MyPage>();
}
```

## Installation

```shell
dotnet add package JeyDotC.JustCs --version 1.1.0
dotnet add package JeyDotC.JustCs.Mvc --version 1.0.0
```

## Setup

At your Startup.cs file, add this to your controller options:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers(options =>
    {
        options.WithJustCs(); //<-- This allows API controllers to render JustCs HTML views.
    });
}
```

## Basic Usage

### Create a component

Just create a class that extends `ComponentElement` (or `ComponentElement<>`) and implement the `Render` method.

```csharp
public class MyPage : ComponentElement
{
    protected override Element Render(IElementAttributes props) =>
        _<Html>(
            _<Head>(
                _<Title>("Hello World")
            ),
            _<Body>(
                _<H1>("Hello from JustCs!")
                _<Form>(new Attrs { Method = "POST", Action = "/login" },
                    _<Label>(new Attrs { For = "username" }, "Username"),
                    _<Input>(new Attrs { Id = "username", Name = "username", Type = "text", Placeholder = "User Name" }),

                    _<Label>(new Attrs { For = "password" }, "Password"),
                    _<Input>(new Attrs { Id = "username", Name = "username", Type = "password" }),

                    _<Button>(new Attrs { Type = "submit" }, "Login"),
                )
            )
        );
}
```

### Return the view as a response

At your controller, just create a `View<>` instance which will serve as the HTTP response.

```csharp
[ApiController]
[Route("[controller]")]
public class MyPageController : ControllerBase
{
    [HttpGet]
    public IView Index() => new View<MyPage>();
}
```

The View class, since it serves as the response, which means you can set the status code and headers too.

```csharp
[ApiController]
[Route("[controller]")]
public class MyPageController : ControllerBase
{
    [HttpGet]
    public IView Index() => new View<MyPage>();

    [HttpGet]
    public IView Error() => new View<MyErrorPage>(null, HttpStatusCode.ServerError)
                    .WithHeader("X-Some-Header", "some-value");
}
```

### Return as IActionResult

If you're returning an IAction result instance, you can use the `MvcView<>` class instead.

```csharp
[Route("[controller]")]
public class MyPageController : Controller
{
    [Route("Create")]
    [HttpGet]
    public IActionResult Create() => new MvcView<Create>(new CreateProps {});

    [Route("Create")]
    [HttpPost]
    public IActionResult Create([FromForm] CreateProps createProps)
    {
        // You can use ModelState as long as the form follows the
        // inputs naming rules and annotate the props with the
        // necessary attributes.
        // See https://github.com/JeyDotC/JustCs/tree/develop/Example.Mvc
        // for a full example on basic MVC work flow.
        if (!ControllerContext.ModelState.IsValid)
        {
            return new MvcView<Create>(createProps with
            {
                Validation = ControllerContext.ModelState,
            }, HttpStatusCode.BadRequest);
        }

        // If everything is Ok, store your data and redirect.

        return Redirect("/");
    }
}
```