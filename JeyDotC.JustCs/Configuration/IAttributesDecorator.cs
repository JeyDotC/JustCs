using System;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs.Configuration
{
#nullable enable
    public struct AttributesContext
    {
        public IElementAttributes? Attributes { get; init; }
        public Type ElementType { get; init; }

        public void Deconstruct(out IElementAttributes? attributes, out Type elementType)
        {
            attributes = Attributes;
            elementType = ElementType;
        }
    }

    public interface IAttributesDecorator
    {
        public IElementAttributes? Decorate(AttributesContext attributesContext);
    }
}