using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs.Configuration
{
#nullable enable
    public interface IAttributesDecorator
    {
        public IElementAttributes? Decorate(IElementAttributes? attributes);
    }
}