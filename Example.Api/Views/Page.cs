using System;
using Example.Api.Views.Components;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace Example.Api.Views
{
    public struct PageProps : IElementAttributes
    {
        public string Lang { get; init; }

        public string Title { get; init; }

        public Fragment Head { get; init; }

        public string Page { get; init; }
    }

    public class Page : ComponentElement<PageProps>
    {
        protected override Element Render(PageProps props)
            => _<Html>(
                    new Attrs { Lang = props.Lang ?? "en" },
                _<Head>(
                    _<Meta>(new Attrs { Charset = "utf-8" }),
                    _<Meta>(new Attrs { Name = "viewport", Content = "width=device-width, initial-scale=1" }),

                    _<Link>(new Attrs { Href= "https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css", Rel= "stylesheet", }),

                    props.Head ?? _(),

                    _<Title>(props.Title)
                ),
                _<Body>(
                    _<NavBar>(new NavBarProps {
                        Page = props.Page
                    }),

                    _<Div>(new Attrs { Class = "container" }, _(Children)),

                    _<Script>(new Attrs { Src = "https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" })
                )
            );
    }
}
