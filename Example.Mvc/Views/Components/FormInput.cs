using System;
using System.Collections.Generic;
using System.Linq;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace Example.Mvc.Views.Components
{
    public record FormInputProps : IElementAttributes
    {
        public string Id { get; init; }
        public string Label { get; init; }
        public string Name { get; init; }
        public string Value { get; init; }
        public string Type { get; init; } = "text";
        public string Placeholder { get; init; } = "";
        public IEnumerable<string> Errors { get; init; } = Enumerable.Empty<string>();
    }

    public sealed class FormInput : ComponentElement<FormInputProps>
    {
        protected override Element Render(FormInputProps attributes)
            => _<Div>(new Attrs { Class = "mb-3 has-validation" },
                _<Label>(new Attrs { For = attributes.Id, Class = "form-label" }, attributes.Label),
                _<Input>(new Attrs
                {
                    Type = attributes.Type,
                    Class = ClassNames.From("form-control", ("is-invalid", attributes.Errors.Any())),
                    Id = attributes.Id,
                    Value = attributes.Value,
                    Name = attributes.Name,
                    Placeholder = attributes.Placeholder,
                }),
                _(attributes.Errors.Select(e => _<Div>(new Attrs { Class = "invalid-feedback" }, e)))
            );
    }
}
