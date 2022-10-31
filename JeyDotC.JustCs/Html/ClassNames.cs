using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace JeyDotC.JustCs.Html
{
    public enum PropertyAsClassBehavior
    {
        TransformToDashCase,
        AsIs,
    }

    public static class ClassNames
    {
        public static string From(params object[] classSpecs)
            => classSpecs
                .Select(ToClassName)
                .JoinNames();

        public static ValueTuple<object, PropertyAsClassBehavior> AsIs(this object classNamesDictionary) => (classNamesDictionary, PropertyAsClassBehavior.AsIs);

        public static ValueTuple<object, PropertyAsClassBehavior> TransformToDashCase(this object classNamesDictionary) => (classNamesDictionary, PropertyAsClassBehavior.TransformToDashCase);

        private static string ToClassName(object? spec)
        {
            if (spec is null)
            {
                return string.Empty;
            }

            if (spec is string)
            {
                return (string)spec;
            }

            if (spec.GetType().IsPrimitive || spec is Enum)
            {
                return spec.ToString() ?? string.Empty;
            }

            if (spec is ValueTuple<string, bool>)
            {
                var (className, render) = (ValueTuple<string, bool>)spec;
                return render ? className : string.Empty;
            }

            if (spec is ITuple)
            {
                var tuple = (ITuple)spec;
                var innerSpec = tuple[0];
                var nameBehavior = tuple[1];

                return HandleClassNameDictionary(
                    innerSpec ?? new { },
                    nameBehavior is not null
                    ? (PropertyAsClassBehavior)nameBehavior
                    : PropertyAsClassBehavior.TransformToDashCase
                );
            }

            return HandleClassNameDictionary(spec);
        }

        private static string JoinNames(this IEnumerable<string> nameList)
            => string.Join(' ', nameList.Where(name => !string.IsNullOrWhiteSpace(name)));

        private static string HandleClassNameDictionary(object spec, PropertyAsClassBehavior behavior = PropertyAsClassBehavior.TransformToDashCase)
            => spec.GetType().GetProperties()
                .Where(p => (p.GetValue(spec) as bool?).GetValueOrDefault(false))
                .Select(p => TransformName(p.Name, behavior))
                .JoinNames();

        private static string TransformName(string name, PropertyAsClassBehavior behavior)
            => behavior switch
            {
                PropertyAsClassBehavior.TransformToDashCase => name.ToDashCase().ToLower(),
                _ => name
            };
    }
}
