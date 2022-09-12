using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Example.Api.Views.Components;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Example.Api.Views.Home
{
    public record NewProps : IElementAttributes
    {
        [Required]
        public string Name { get; set; }

        [BindNever]
        public ModelStateDictionary Validation { get; set; }

        internal IEnumerable<string> GetErrorsFor(string field)
        {
            if(Validation == null || Validation[field] == null)
            {
                return Enumerable.Empty<string>();
            }

            return Validation[field].Errors.Select(e => e.ErrorMessage);
        }
    }

    public class New : ComponentElement<NewProps>
    {
        protected override Element Render(NewProps attributes)
            => _<Page>(new PageProps { Title = "Create Foo", Page = "Home/Index", },
                _<Form>(new Attrs { Action = "/New", Method="POST" },
                 _<FormInput>(new FormInputProps {
                     Id = "Name",
                     Label = "Name",
                     Name = "Name",
                     Value = attributes.Name,
                     Placeholder = "John Foo",
                     Errors=attributes.GetErrorsFor(nameof(attributes.Name))
                 }),
                 _<Button>(new Attrs { Type="submit", Class="btn btn-primary" }, "Create")
                )
            );
    }
}
