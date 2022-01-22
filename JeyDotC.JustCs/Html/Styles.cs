using System;
using System.Linq;

namespace JeyDotC.JustCs.Html
{
    public static class Styles
    {
        public static string From(object stylesSpec)
        {
            if(stylesSpec == null)
            {
                return string.Empty;
            }

            var styleParts = stylesSpec.GetType().GetProperties()
                .Select(p => (p.Name, p.GetValue(stylesSpec)?.ToString()))
                .Where(tuple => !string.IsNullOrEmpty(tuple.Item2))
                .Select(tuple => $"{tuple.Item1.ToDashCase().ToLower()}: {tuple.Item2};");

            return string.Join(' ', styleParts);
        }

        public static string Px(this object value) => FormattableString.Invariant($"{value}px");
        public static string Percent(this object value) => FormattableString.Invariant($"{value}%");
        public static string Em(this object value) => FormattableString.Invariant($"{value}em");
    }
}
