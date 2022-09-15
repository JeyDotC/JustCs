using System;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace Example.Mvc.Views.Components
{
    public struct NavBarProps : IElementAttributes
    {
        public string Page { get; init; }
    }

    public sealed class NavBar : ComponentElement<NavBarProps>
    {
        protected override Element Render(NavBarProps props)
            => _<Nav>(new Attrs { Class = ClassNames.From("navbar navbar-expand-lg navbar-dark bg-dark") },
                    _<Div>(new Attrs { Class = "container-fluid" },
                        _<A>(new Attrs { Class = "navbar-brand", Href = "/" }, "JustCs"),
                        _<Button>(new Attrs
                            {
                                Class = "navbar-toggler",
                                Type = "button",
                                DataSet = new
                                {
                                    bsToggle = "collapse",
                                    bsTarget = "#navbarSupportedContent",
                                }
                            },
                            _<Span>(new Attrs { Class = "navbar-toggler-icon" })
                        ),
                        _<Div>(new Attrs { Class = "collapse navbar-collapse", Id = "navbarSupportedContent" },
                            _<Ul>(new Attrs { Class = "navbar-nav me-auto mb-2 mb-lg-0" },

                                _<Li>(new Attrs { Class = "nav-item" },
                                    _<A>(new Attrs { Class = ClassNames.From("nav-link", ("active", props.Page == "Home/Index")), Href = "/" },
                                        "Home"
                                    )
                                )
                            )
                        )
                    )
                );
    }
}
