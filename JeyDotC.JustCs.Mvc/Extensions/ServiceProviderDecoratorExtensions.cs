using System;
using JeyDotC.JustCs.Configuration.Decorators;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace JeyDotC.JustCs.Mvc.Extensions
{
    public static class ServiceProviderDecoratorExtensions
    {
        public static ServiceProviderAttributesDecorator WithHttpContextAccessor(this ServiceProviderAttributesDecorator self)
        {
            self.WithResolver((context) =>
            {
                var (serviceProvider, propertyType, _) = context;

                if (propertyType != typeof(HttpContext))
                {
                    return null;
                }

                var httpContextAccessor = serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor
                    ?? throw new InvalidOperationException(
                        "HttpContext is not available at service provider, did you forget to call services.AddHttpContextAccessor() in your Startup class?"
                    );

                return httpContextAccessor.HttpContext;
            });

            return self;
        }
    }
}

