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
        internal static Element CreateElement<TElement>(IElementAttributes? providedAttributes, IEnumerable<Element> children)
            where TElement : Element, new()
        {
            var elementType = typeof(TElement);

            // Only apply decorators to Component elements.
            if (!elementType.IsAssignableTo(typeof(ComponentElement)))
            {
                return new TElement() { Attributes = providedAttributes, Children = children };
            }

            var processedAttributes = JustCsSettings.AttributeDecorators.ToArray().Aggregate(
                    providedAttributes,
                    (accumulate, decorator) => decorator.Decorate(new AttributesContext
                    {
                        Attributes = accumulate,
                        ElementType = elementType,
                    })
                );

            return new TElement() { Attributes = processedAttributes, Children = children };
        }
    }
}

