using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace JeyDotC.JustCs.Mvc
{
    public sealed class HtmlOutputFormatter : IOutputFormatter
    {
        public bool CanWriteResult(OutputFormatterCanWriteContext context)
            => typeof(IView).IsAssignableFrom(context.ObjectType) && context.Object != null;

        
        public Task WriteAsync(OutputFormatterWriteContext context)
        {
            var view = (IView)context.Object;

            context.ContentType = "text/html";

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;

            if (view is HttpResponseMessage)
            {
                var message = (HttpResponseMessage)view;
                context.HttpContext.Response.StatusCode = (int)message.StatusCode;
                foreach(var headerEntry in message.Headers)
                {
                    context.HttpContext.Response.Headers[headerEntry.Key] = headerEntry.Value.ToArray();
                }
            }

            var rootElement = view.GetElement();
            var content = rootElement.RenderAsHtml();

            return context.HttpContext.Response.WriteAsync($"<!DOCTYPE html>\n{content}");
        }
    }
}
