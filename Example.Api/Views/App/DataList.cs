using System;
using System.Collections.Generic;
using System.Linq;
using Example.Api.Model;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace Example.Api.Views.App
{
    public struct DataListProps : IElementAttributes
    {
        public IEnumerable<Data> Results { get; init; }
    }

    public class DataList : ComponentElement<DataListProps>
    {
        protected override Element Render(DataListProps props)
            => _<Page>(new PageProps { Title = "Data List", Page = "App/DataList" },
                _<H1>("Let's display some data"),
                _<Table>(new Attrs { Class = "table" },
                    _<Header>(
                        _<Tr>(
                            _<Th>("Id"),
                            _<Th>("Name"),
                            _<Th>("Description"),
                            _<Th>(new Attrs { Class = "text-end" }, "Quantity")
                        )
                    ),
                    _<Tbody>(
                        _(props.Results.Select(entry => _<Tr>(
                            _<Td>(entry.Id),
                            _<Td>(entry.Name),
                            _<Td>(
                                _<P>(entry.Description)
                            ),
                            _<Td>(new Attrs { Class="text-end" },
                                _<Strong>(entry.Quantity)
                            )
                        )))
                    )
                )
            );
    }
}
