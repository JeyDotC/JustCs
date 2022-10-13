using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace JeyDotC.JustCs.Configuration
{
#nullable enable
    public static class JustCsSettings
    {
        public static ISet<IAttributesDecorator> AttributeDecorators { get; } = new AttributesDecoratorSet();
    }
}

