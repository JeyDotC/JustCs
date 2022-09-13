using System;
using System.Collections.Generic;
using System.Linq;
using Example.Api.Model.Models;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace Example.Api.Views.Home
{
    public record IndexProps : IElementAttributes
    {
        public IEnumerable<Foo> Foos { get; init; }

        public string __RequestVerificationToken { get; init; }
    }

    public record DeleteFooData
    {
        public int Id { get; init; }

        public string __RequestVerificationToken { get; init; }
    }

    public class Index : ComponentElement<IndexProps>
    {
        protected override Element Render(IndexProps attributes)
            => _<Page>(new PageProps { Title = "List of Foos", Page = "Home/Index", },
                    _<H1>("Foos ", _<A>(new Attrs { Href="/New", Class="btn btn-success" }, "New Foo")),
                    _<Table>(new Attrs { Class = "table" },
                        _<Caption>($"Presenting {attributes.Foos.Count()} Foos"),
                        _<Thead>(
                            _<Tr>(
                                _<Th>(new Attrs { Class="text-end" }, "Id"),
                                _<Th>("Name"),
                                _<Th>()
                            )
                        ),
                        _<Tbody>(
                            (attributes.Foos.Any(),
                                () => _(attributes.Foos.Select(foo => _<Tr>(
                                    _<Td>(new Attrs { Class = "text-end" }, foo.FooId),
                                    _<Td>(foo.Name),
                                    _<Td>(new Attrs { Class = "hstack gap-3" },
                                        _<A>(new Attrs { Href = $"/Edit/{foo.FooId}", Class = "ms-auto"}, "Edit"),
                                        _<Div>(new Attrs { Class = "vr"}),
                                        _<Form>(new Attrs { Action = $"/Delete", Method = "POST" },
                                            _<Input>(new Attrs { Type = "hidden", Value = attributes.__RequestVerificationToken, Name = nameof(attributes.__RequestVerificationToken) }),
                                            _<Input>(new Attrs { Type = "hidden", Value = foo.FooId.ToString(), Name = "Id" }),

                                            _<Button>(new Attrs { Type="submit", Class="btn btn-danger btn-sm" }, "Delete")
                                        )
                                    )
                                )))
                            ),
                            (!attributes.Foos.Any(),
                                () => _<Tr>(
                                    _<Td>(new Attrs { Class = "text-center text-muted", Colspan = 3 }, "No results"
                                ))
                            )
                    )
                )
            );
    }
}
