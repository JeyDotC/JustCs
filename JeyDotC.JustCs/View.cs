using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs
{
    public interface IView
    {
        Element GetElement();
    }

    public class View<TElement> : HttpResponseMessage, IView
        where TElement : Element, new()
    {
        private readonly IElementAttributes? _props;

        public View(IElementAttributes? props = null, HttpStatusCode code = HttpStatusCode.OK)
            : base(code)
        {
            _props = props;
        }

        public Element GetElement()
            => ElementCreator.CreateElement<TElement>(_props, Enumerable.Empty<Element>());
    }
}
