using System;
namespace JeyDotC.JustCs
{
    public static class ViewExtensions
    {
        public static View<TElement> WithHeader<TElement>(this View<TElement> view, string headerName, params string[] values)
            where TElement : Element, new()
        {
            view.Headers.Add(headerName, values);

            return view;
        }
    }
}
