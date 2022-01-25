using System;
using System.Linq;

namespace JeyDotC.JustCs
{
    internal static class ObjectExtensions
    {
        public static int HeavyGenerateHashCode(this object target)
            => target
            .GetType()
            .GetProperties()
            .Select(p => GetValueHashCode(p.GetValue(target)))
            .Aggregate((total, nextCode) => total ^ nextCode);

        private static int GetValueHashCode(object value)
            => value == null ? 0 : value.GetHashCode();

    }
}
