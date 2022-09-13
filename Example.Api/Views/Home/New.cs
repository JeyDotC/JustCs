using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Example.Api.Extensions;
using Example.Api.Views.Components;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Example.Api.Views.Home
{
    public record NewProps : IValidatedProps
    {
        [Required]
        public string Name { get; set; }

        public string __RequestVerificationToken { get; set; }

        [BindNever]
        public ModelStateDictionary Validation { get; init; }
    }

    public class New : ComponentElement<NewProps>
    {
        protected override Element Render(NewProps attributes)
            => _<Page>(new PageProps { Title = "Create Foo", Page = "Home/Index", },
                _<A>(new Attrs { Href = "/" }, "< Return"),
                _<Form>(new Attrs { Action = "/New", Method="POST" },

                    _<Input>(new Attrs { Type="hidden", Value = attributes.__RequestVerificationToken, Name=nameof(attributes.__RequestVerificationToken)}),

                    _<FormInput>(new FormInputProps {
                        Id = "Name",
                        Label = "Name",
                        Name = nameof(attributes.Name),
                        Value = attributes.Name,
                        Placeholder = "John Foo",
                        Errors=attributes.GetErrorsFor(nameof(attributes.Name))
                    }),

                    _<Button>(new Attrs { Type="submit", Class="btn btn-primary" }, "Create")
                )
            );
    }
}
