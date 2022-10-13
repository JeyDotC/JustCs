using System;
using System.Collections.Generic;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs.Configuration
{
#nullable enable
    public static class ConfigurationExtensions
    {
        public static bool Add(this ISet<IAttributesDecorator> self, DecorateImplementation implementation)
            => self.Add(new DelegateAttributesDecorator(implementation));
    }
}

