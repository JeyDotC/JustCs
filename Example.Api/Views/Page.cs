using System;
using System.Collections.Generic;
using System.Linq;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace MrPapaya.Api.Views
{
    public struct PageProps : IElementAttributes
    {
        public string Lang { get; init; }

        public string Title { get; init; }

        public IEnumerable<string> Css { get; init; }

        public IEnumerable<string> Scripts { get; init; }
    }

    public class Page : ComponentElement<PageProps>
    {
        private static IEnumerable<Element> Links(IEnumerable<string> cssFiles)
            => (cssFiles ?? Array.Empty<string>())
                .Select(css => _<Link>(new Attrs { Href = css, Rel = "stylesheet" }));

        private static IEnumerable<Element> Scripts(IEnumerable<string> scripts)
            => (scripts ?? Array.Empty<string>()).Select(script => _<Script>(new Attrs {
                Src = script,
                Type = "module",
            }));

        protected override Element Render(PageProps props) =>

            _<Html>(new Attrs { Lang = props.Lang ?? "en" },

                _<Head>(
                    _<Title>(props.Title),
                    _(Links(props.Css))
                ),

                _<Body>(
                    _(Children),
                    _(Scripts(props.Scripts))
                )
            );
    }
}
