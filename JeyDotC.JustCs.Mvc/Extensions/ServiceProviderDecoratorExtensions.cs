using System;
using JeyDotC.JustCs.Configuration.Decorators;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace JeyDotC.JustCs.Mvc.Extensions
{
    public static class ServiceProviderDecoratorExtensions
    {
        public static ServiceProviderAttributesDecorator WithHttpContextAccessor(this ServiceProviderAttributesDecorator self)
             => self.WithResolver(ResolveHttpContext);

        /// <summary>
        /// Tries to extract the HttpContext from the provided IServiceProvider
        /// instance through the IHttpContextAccessor. This function is public
        /// for testing purposes.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static object? ResolveHttpContext(ResolutionContext context)
        {
            var (serviceProvider, property) = context;

            if (property.PropertyType != typeof(HttpContext))
            {
                return null;
            }

            var httpContextAccessor = serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor
                ?? throw new InvalidOperationException(
                    "HttpContext is not available at service provider, did you forget to call services.AddHttpContextAccessor() in your Startup class?"
                );

            return httpContextAccessor.HttpContext;
        }
    }
}

