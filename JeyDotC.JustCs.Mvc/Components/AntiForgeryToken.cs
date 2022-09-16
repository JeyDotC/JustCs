using System;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using Microsoft.AspNetCore.Antiforgery;

namespace JeyDotC.JustCs.Mvc.Components
{
    public class AntiForgeryToken : ComponentElement
    {
        protected override Element Render(IElementAttributes attributes)
        {
            var tokenStore = MvcContext.GetService<IAntiforgery>().GetAndStoreTokens(MvcContext.Context);

            return _<Input>(new Attrs
            {
                Type = "hidden",
                Name = tokenStore.FormFieldName,
                Value = tokenStore.RequestToken
            });
        }
    }
}

