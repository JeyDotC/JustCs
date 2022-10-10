using System;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs.Configuration
{
#nullable enable
    public delegate IElementAttributes? DecorateImplementation(IElementAttributes? elementAttributes, Type elementType);

    public class DelegateAttributesDecorator : IAttributesDecorator
    {
        private readonly DecorateImplementation _implementation;

        public DelegateAttributesDecorator(DecorateImplementation implementation)
        {
            _implementation = implementation;
        }

        public IElementAttributes? Decorate(AttributesContext attributesContext)
            => _implementation(attributesContext.Attributes, attributesContext.ElementType);
    }
}

