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
        private static IElementAttributes? ExtractDefaultProps<TElement>()
            where TElement : Element, new()
        {
            var value = typeof(TElement).GetProperty("DefaultAttributes")?.GetValue(null);

            if (value is IElementAttributes)
            {
                return (IElementAttributes)value;
            }

            return null;
        }

        internal static Element CreateElement<TElement>(IElementAttributes? attributes, IEnumerable<Element> children)
            where TElement : Element, new()
        {
            var processedAttributes = JustCsSettings.AttributeDecorators.ToArray().Aggregate(
                    attributes ?? ExtractDefaultProps<TElement>(),
                    (accumulate, decorator) => decorator.Decorate(accumulate)
                );

            return new TElement() { Attributes = processedAttributes, Children = children };
        }
    }
}

