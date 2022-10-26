using System;
using JeyDotC.JustCs.Configuration;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace JeyDotC.JustCs.Mvc.Components
{
    public record AntiForgeryTokenProps : IElementAttributes
    {
        [Inject]
        public HttpContext HttpContext { get; set; }

        [Inject(Required = true)]
        public IAntiforgery AntiForgery { get; init; }
    }

    public class AntiForgeryToken : ComponentElement<AntiForgeryTokenProps>
    {
        public static AntiForgeryTokenProps DefaultAttributes => new AntiForgeryTokenProps();

        protected override Element Render(AntiForgeryTokenProps attributes)
        {
            var tokenStore = attributes.AntiForgery.GetAndStoreTokens(attributes.HttpContext);

            return _<Input>(new Attrs
            {
                Type = "hidden",
                Name = tokenStore.FormFieldName,
                Value = tokenStore.RequestToken
            });
        }
    }
}

