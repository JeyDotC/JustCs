using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JeyDotC.JustCs.Html.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace JeyDotC.JustCs.Mvc
{
    public class MvcView<TElement> : View<TElement>, IActionResult
        where TElement : Element, new()
    {
        private readonly ObjectResult _implementation;

        public MvcView(IElementAttributes attributes, HttpStatusCode code = HttpStatusCode.OK)
            : base(attributes, code) => _implementation = new ObjectResult(this);

        public Task ExecuteResultAsync(ActionContext context) => ((IActionResult)_implementation).ExecuteResultAsync(context);
    }
}
