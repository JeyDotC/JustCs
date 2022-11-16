using System;
namespace JeyDotC.JustCs.Testing
{
    public static class ElementExtensions
    {
        /// <summary>
        /// Recuresively renders an element or component and its children.
        /// Generating a HTML tree. This function exists for testing and
        /// debugging purposes only.
        /// </summary>
        /// <param name="componentOrElement"></param>
        /// <returns></returns>
        public static Element RenderAsHtmlTree(this Element componentOrElement)
        {
            var element = componentOrElement is ComponentElement
                ? ((ComponentElement)componentOrElement).RenderAsElement()
                : componentOrElement;

            element
                .GetType()
                .GetProperty(nameof(element.Children))?
                .SetValue(
                    element,
                    element.Children
                        .SelectMany(c =>
                        {
                            var childElement = c.RenderAsHtmlTree();

                            if (childElement is Fragment)
                            {
                                return childElement.Children;
                            }

                            return new Element[] { childElement };
                        })
                        .ToArray()
                );

            return element;
        }
    }
}

