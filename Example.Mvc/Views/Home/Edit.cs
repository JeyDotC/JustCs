using System;
using System.ComponentModel.DataAnnotations;
using Example.Mvc.Extensions;
using Example.Mvc.Views.Components;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using JeyDotC.JustCs.Mvc.Components;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Example.Mvc.Views.Home
{
    public record EditProps : IValidatedProps
    {
        public int Id { get; init; }

        [Required]
        public string Name { get; init; }

        [BindNever]
        public ModelStateDictionary Validation { get; init; }
    }

    public sealed class Edit : ComponentElement<EditProps>
    {
        protected override Element Render(EditProps attributes)
            => _<Page>(new PageProps { Title = "Edit Foo", Page = "Home/Index", },
                _<A>(new Attrs { Href = "/" }, "< Return"),

                _<H1>($"Edit '{attributes.Name}'"),
                _<Form>(new Attrs { Action = "/Edit", Method = "POST" },

                    _<AntiForgeryToken>(),

                    _<Input>(new Attrs { Type = "hidden", Name = "Id", Value = attributes.Id.ToString(), }),
                    _<FormInput>(new FormInputProps
                    {
                        Id = "Name",
                        Label = "Name",
                        Name = "Name",
                        Value = attributes.Name,
                        Placeholder = "John Foo",
                        Errors = attributes.GetErrorsFor(nameof(attributes.Name))
                    }),
                    _<Button>(new Attrs { Type = "submit", Class = "btn btn-primary" }, "Save")
                )
            );
    }
}
