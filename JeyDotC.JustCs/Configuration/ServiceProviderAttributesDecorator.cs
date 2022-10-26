using System;
using System.Linq;
using System.Reflection;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs.Configuration
{
#nullable enable
    public sealed class ServiceProviderAttributesDecorator : IAttributesDecorator
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceProviderAttributesDecorator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IElementAttributes? Decorate(AttributesContext attributesContext)
        {
            var (attributes, componentType) = attributesContext;

            if (attributes == null)
            {
                return attributes;
            }

            var injectableAttributes = attributes
                .GetType()
                .GetProperties()
                .Select(prop => (prop, prop.GetCustomAttribute<InjectAttribute>()));

            foreach (var (attr, annotation) in injectableAttributes)
            {
                if(annotation is null)
                {
                    continue;
                }

                var resolvedValue = _serviceProvider.GetService(attr.PropertyType);

                if(annotation.Required && resolvedValue is null)
                {
                    throw new InvalidOperationException($"{componentType.Name} attribute {attr.Name} is required, but could not be resolved.");
                }

                attr.SetValue(attributes, resolvedValue);
            }

            return attributes;
        }
    }
}

