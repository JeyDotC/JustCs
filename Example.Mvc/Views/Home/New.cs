﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Example.Mvc.Extensions;
using Example.Mvc.Views.Components;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using JeyDotC.JustCs.Mvc.Components;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Example.Mvc.Views.Home
{
    public record NewProps : IValidatedProps
    {
        [Required]
        public string Name { get; init; }

        [BindNever]
        public ModelStateDictionary Validation { get; init; }
    }

    public sealed class New : ComponentElement<NewProps>
    {
        protected override Element Render(NewProps attributes)
            => _<Page>(new PageProps { Title = "Create Foo", Page = "Home/Index", },
                _<A>(new Attrs { Href = "/" }, "< Return"),
                _<H1>("New Foo"),
                _<Form>(new Attrs { Action = "/New", Method="POST" },

                    _<AntiForgeryToken>(),

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
