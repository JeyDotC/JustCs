using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs.Configuration.Decorators
{
    public delegate object? Resolve(ResolutionContext context);

    public sealed class ServiceProviderAttributesDecorator : IAttributesDecorator
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly ISet<Resolve> _resolutionStack = new HashSet<Resolve>
        {
            DefaultResolve
        };

        private static object? DefaultResolve(ResolutionContext context)
            => context.ServiceProvider.GetService(context.Property.PropertyType);

        public ServiceProviderAttributesDecorator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ServiceProviderAttributesDecorator WithResolver(Resolve resolver)
        {
            _resolutionStack.Add(resolver);
            return this;
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
                if (annotation is null)
                {
                    continue;
                }

                var resolvedValue = DoResolve(new ResolutionContext
                {
                    InjectInfo = annotation,
                    Property = attr,
                    ServiceProvider = _serviceProvider,
                    ComponentType = componentType,
                });

                if (annotation.Required && resolvedValue is null)
                {
                    throw new InvalidOperationException($"{componentType.Name} attribute {attr.Name} is required, but could not be resolved.");
                }

                attr.SetValue(attributes, resolvedValue);
            }

            return attributes;
        }

        private object? DoResolve(ResolutionContext context)
        {
            foreach (var resolve in _resolutionStack)
            {
                var result = resolve(context);

                if(result is not null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}

