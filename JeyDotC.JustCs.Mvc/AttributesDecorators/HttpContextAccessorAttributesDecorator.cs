using System;
using System.Linq;
using JeyDotC.JustCs.Configuration;
using JeyDotC.JustCs.Html.Attributes;
using Microsoft.AspNetCore.Http;

namespace JeyDotC.JustCs.Mvc.AttributesDecorators
{
#nullable enable
    public sealed class HttpContextAccessorAttributesDecorator : IAttributesDecorator
    {
        private readonly IServiceProvider _serviceProvider;

        public HttpContextAccessorAttributesDecorator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IElementAttributes? Decorate(IElementAttributes? attributes)
        {
            if (attributes == null)
            {
                return attributes;
            }

            var contextRequiringProperty = attributes.GetType()
                .GetProperties()
                .FirstOrDefault(p => p.GetCustomAttributes(false).Any(a => a is InjectAttribute) && p.PropertyType == typeof(HttpContext));

            if(contextRequiringProperty == null)
            {
                return attributes;
            }

            var httpContextAccessor = _serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor
                ?? throw new InvalidOperationException(
                    "HttpContext is not available at service provider, did you forget to call services.AddHttpContextAccessor() in your Startup class?"
                );

            contextRequiringProperty.SetValue(attributes, httpContextAccessor.HttpContext);

            return attributes;
        }
    }
}

