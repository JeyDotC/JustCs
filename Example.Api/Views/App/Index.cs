using System;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace Example.Api.Views.App
{
    public class Index : ComponentElement
    {
        protected override Element Render(IElementAttributes attributes)
            => _<Page>(new PageProps { Title = "Home Page", Page = "App/Index", },
                    _<H1>("Sample App")
                );
    }
}
