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
                                _<Th>(new Attrs { Class="text-right" }, "Id"),
                                _<Th>("Name"),
                                _<Th>()
                            )
                        ),
                        _<Tbody>(
                            (attributes.Foos.Any(),
                                () => _(attributes.Foos.Select(foo => _<Tr>(
                                    _<Td>(new Attrs { Class = "text-right" }, foo.FooId),
                                    _<Td>(foo.Name),
                                    _<Td>()
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
