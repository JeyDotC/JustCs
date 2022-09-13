using System;
using System.Collections.Generic;
using System.Linq;
using JeyDotC.JustCs.Html.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Example.Api.Extensions
{
    internal interface IValidatedProps : IElementAttributes
    {
        [BindNever]
        ModelStateDictionary Validation { get; }
    }

    internal static class IValidatedPropsExtensions
    {
        internal static IEnumerable<string> GetErrorsFor(this IValidatedProps self, string field)
        {
            if (self.Validation == null || self.Validation[field] == null)
            {
                return Enumerable.Empty<string>();
            }

            return self.Validation[field].Errors.Select(e => e.ErrorMessage);
        }
    }
}
