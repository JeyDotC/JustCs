﻿using System;
using System.Linq;
using System.Collections.Generic;
using JeyDotC.JustCs.Configuration;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustCs
{
    struct EmptyProps : IElementAttributes { }
    public abstract class ComponentElement : Element
    {
        public override string Tag => GetType().Name;

        internal Element ToElement()
        {
            var result = Render(Attributes);
            if (result is ComponentElement)
            {
                return ((ComponentElement)result).ToElement();
            }

            return result;
        }

        protected abstract Element Render(IElementAttributes? attributes);

        protected static Element _(params Element[] children)
             => ElementCreator.CreateElement<Fragment>(null, children);

        protected static Element _(IEnumerable<Element> children)
             => ElementCreator.CreateElement<Fragment>(null, children);

        protected static Element _<TElement>(params Element[] children)
            where TElement : Element, new()
            => ElementCreator.CreateElement<TElement>(null, children);

        protected static Element _<TElement>(IElementAttributes? attributes, params Element[] children)
            where TElement : Element, new()
            => ElementCreator.CreateElement<TElement>(attributes, children);

        protected static Element _<TElement>(IEnumerable<Element> children)
            where TElement : Element, new()
            => ElementCreator.CreateElement<TElement>(null, children);

        protected static Element _<TElement>(IElementAttributes? attributes, IEnumerable<Element> children)
            where TElement : Element, new()
            => ElementCreator.CreateElement<TElement>(attributes, children);
    }

    public abstract class ComponentElement<TAttributes> : ComponentElement
        where TAttributes : IElementAttributes
    {
        protected override Element Render(IElementAttributes? props)
        {
            if (!(props is TAttributes))
            {
                throw new InvalidOperationException($"{nameof(props)} Expected to be of type {typeof(TAttributes).FullName} received {props?.GetType().FullName ?? "null"}");
            }

            return Render((TAttributes)props);
        }

        protected abstract Element Render(TAttributes props);
    }
}
