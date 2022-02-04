using System;
using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace Example.Api.Views.App
{
    public class Index : ComponentElement
    {
        protected override Element Render(IElementAttributes attributes)
            => _<Page>(new PageProps { Title = "Home Page", Page = "App/Index", },
                    _<H1>("Sample App"),
                    // If you send a tuple of a boolean followed by an element,
                    // the element will be added to the child list only if the boolean is true.
                    (true, "This text is visible"),
                    (false, "This text is Not visible"),
                    (true, _<P>("A Paragraph!")),
                    (false, _<P>("A Paragraph! (Not visible)")),

                    // If you send a tuple of a boolean followed by Func<Element>, the func
                    // will be invoked only if the boolean is true.
                    (true, () => _<P>("A deferred component!")),
                    (false, () => _<P>("A deferred component! (Not visible)"))
                );
    }
}
