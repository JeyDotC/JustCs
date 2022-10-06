using System;
using System.Collections.Generic;

namespace JeyDotC.JustCs.Configuration
{
    public static class JustCsSettings
    {
        public static IList<IAttributesDecorator> AttributeDecorators { get; } = new List<IAttributesDecorator>();
    }
}

