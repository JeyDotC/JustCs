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

## Setup

## Usage
