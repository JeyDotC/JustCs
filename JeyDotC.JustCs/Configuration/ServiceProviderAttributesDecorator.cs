using System;
using System.Linq;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs.Configuration
{
#nullable enable
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class InjectAttribute : Attribute { }

    public sealed class ServiceProviderAttributesDecorator : IAttributesDecorator
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceProviderAttributesDecorator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IElementAttributes? Decorate(IElementAttributes? attributes)
        {
            if(attributes == null)
            {
                return attributes;
            }

            var injectableAttributes = attributes
                .GetType()
                .GetProperties()
                .Where(prop => prop.GetCustomAttributes(false).Any(attr => attr is InjectAttribute));

            foreach(var attr in injectableAttributes)
            {
                var resolvedValue = _serviceProvider.GetService(attr.PropertyType);
                attr.SetValue(attributes, resolvedValue);
            }

            return attributes;
        }
    }
}

