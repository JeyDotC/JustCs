using System;
using JeyDotC.JustCs.Html.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace JeyDotC.JustCs.Configuration
{
#nullable enable
    public class DefaultPropsDecorator : IAttributesDecorator
    {
        public IElementAttributes? Decorate(AttributesContext attributesContext)
        {
            var (providedAttributes, elementType) = attributesContext;

            // Only apply the process to Component elements.
            if (!elementType.IsAssignableTo(typeof(ComponentElement)))
            {
                return providedAttributes;
            }

            var defaultAttributesClone = ExtractDefaultProps(elementType);

            return AttemptMerge(providedAttributes, defaultAttributesClone);
        }

        private static object ShallowClone(object self)
        {
            var clonedObjectType = self.GetType();

            try {
                var clone = Activator.CreateInstance(clonedObjectType) ?? throw new InvalidOperationException($"Object could not be cloned: Provide a parameterless constructor for {clonedObjectType.FullName} so it can be shallow cloned.");

                foreach (var property in clonedObjectType.GetProperties())
                {
                    property.SetValue(clone, property.GetValue(self));
                }

                return clone;
            } catch(Exception e) when (
                e is MissingMethodException ||
                e is MemberAccessException ||
                e is MethodAccessException
            )
            {
                throw new InvalidOperationException($"Object could not be cloned: Provide a parameterless constructor for {clonedObjectType.FullName} so it can be shallow cloned.");
            }
        }

        private static IElementAttributes? ExtractDefaultProps(Type elementType)
        {
            var value = elementType.GetProperty("DefaultAttributes")?.GetValue(null);

            if (value is IElementAttributes)
            {
                return (IElementAttributes)ShallowClone(value);
            }

            return null;
        }

        private static IElementAttributes? AttemptMerge(
            IElementAttributes? receivedAttributes,
            IElementAttributes? defaultAttributesClone
            )
        {
            // User didn't provide attributes nor defined DefaultAttributes.
            if (receivedAttributes is null && defaultAttributesClone is null)
            {
                return null;
            }

            // User didn't provide attributes, but DefaultAttributes is not null.
            if (receivedAttributes is null)
            {
                return defaultAttributesClone;
            }

            // User provided attributes, but didn't define DefaultAttributes.
            if (defaultAttributesClone is null)
            {
                return receivedAttributes;
            }

            // Both, attribute kinds have been provided, we try to nerge default
            // attribtes into provided attributes that are null.
            var defaultAttributesType = defaultAttributesClone.GetType();

            // Received attributes is not an instance of defaultAttributes.
            if (!receivedAttributes.GetType().IsAssignableTo(defaultAttributesType))
            {
                return receivedAttributes;
            }

            foreach (var property in defaultAttributesType.GetProperties())
            {
                var currentValue = property.GetValue(receivedAttributes);

                if (currentValue is not null)
                {
                    continue;
                }

                var defaultValue = property.GetValue(defaultAttributesClone);

                if (defaultValue is not null)
                {
                    property.SetValue(receivedAttributes, defaultValue);
                }
            }


            return receivedAttributes;
        }
    }
}

