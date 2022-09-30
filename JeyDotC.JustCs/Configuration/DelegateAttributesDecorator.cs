using System;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs.Configuration
{
#nullable enable
    public class DelegateAttributesDecorator : IAttributesDecorator
    {
        private readonly Func<IElementAttributes?, IElementAttributes?> _implementation;

        public DelegateAttributesDecorator(Func<IElementAttributes?, IElementAttributes?> implementation)
        {
            _implementation = implementation;
        }

        public IElementAttributes? Decorate(IElementAttributes? attributes)
            => _implementation(attributes);
    }
}

