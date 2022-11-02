using System;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs.Configuration
{
    public delegate IElementAttributes? DecorateImplementation(AttributesContext attributesContext);

    public sealed class DelegateAttributesDecorator : IAttributesDecorator
    {
        private readonly DecorateImplementation _implementation;

        public DelegateAttributesDecorator(DecorateImplementation implementation)
        {
            _implementation = implementation;
        }

        public IElementAttributes? Decorate(AttributesContext attributesContext)
            => _implementation(attributesContext);
    }
}

