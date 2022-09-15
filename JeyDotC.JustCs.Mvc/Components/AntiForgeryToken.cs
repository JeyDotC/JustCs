using System;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using Microsoft.AspNetCore.Antiforgery;

namespace JeyDotC.JustCs.Mvc.Components
{
    public class AntiForgeryToken : ComponentElement
    {
        protected override Element Render(IElementAttributes attributes)
            => _<Input>(new Attrs
            {
                Type = "hidden",
                Name = "__RequestVerificationToken",
                Value = MvcContext.GetService<IAntiforgery>().GetAndStoreTokens(MvcContext.Context).RequestToken
            });
    }
}

