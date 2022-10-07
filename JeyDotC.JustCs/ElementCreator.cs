using System;
using JeyDotC.JustCs.Configuration;
using JeyDotC.JustCs.Html.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace JeyDotC.JustCs
{
#nullable enable
    internal static class ElementCreator
    {
        private static object ShallowClone(this object self)
        {
            var clonedObjectType = self.GetType();
            var clone = Activator.CreateInstance(clonedObjectType);

            if(clone is null)
            {
                throw new InvalidOperationException($"Object could not be cloned: Provide a parameterless constructor for {clonedObjectType.FullName} so it can be shallow cloned.");
            }

            foreach (var property in clonedObjectType.GetProperties())
            {
                property.SetValue(clone, property.GetValue(self));
            }

            return clone;
        }

        private static IElementAttributes? ExtractDefaultProps<TElement>()
            where TElement : Element, new()
        {
            var value = typeof(TElement).GetProperty("DefaultAttributes")?.GetValue(null);

            if (value is IElementAttributes)
            {
                return (IElementAttributes)value.ShallowClone();
            }

            return null;
        }

        private static IElementAttributes? AttemptMerge(
            IElementAttributes? receivedAttributes,
            IElementAttributes? defaultAttributesClone
            )
        {
            // User didn't provide attributes nor defined DefaultAttributes.
            if(receivedAttributes is null && defaultAttributesClone is null)
            {
                return null;
            }

            // User didn't provide attributes, but DefaultAttributes is not null.
            if(receivedAttributes is null)
            {
                return defaultAttributesClone;
            }

            // User provided attributes, but didn't define DefaultAttributes.
            if(defaultAttributesClone is null)
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

                if(currentValue is not null)
                {
                    continue;
                }

                var defaultValue = property.GetValue(defaultAttributesClone);

                if(defaultValue is not null)
                {
                    property.SetValue(receivedAttributes, defaultValue);
                }
            }


            return receivedAttributes;
        }

        internal static Element CreateElement<TElement>(IElementAttributes? providedAttributes, IEnumerable<Element> children)
            where TElement : Element, new()
        {
            var defaultAttributesClone = ExtractDefaultProps<TElement>();

            var attributes = AttemptMerge(providedAttributes, defaultAttributesClone);

            var processedAttributes = JustCsSettings.AttributeDecorators.ToArray().Aggregate(
                    attributes,
                    (accumulate, decorator) => decorator.Decorate(accumulate)
                );

            return new TElement() { Attributes = processedAttributes, Children = children };
        }
    }
}

