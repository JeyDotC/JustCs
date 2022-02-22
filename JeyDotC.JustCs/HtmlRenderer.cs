﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using JeyDotC.JustCs.Html;

namespace JeyDotC.JustCs
{
    public static class HtmlRenderer
    {
        private static readonly Regex _tagNameCheck = new Regex("^[A-Za-z]([A-Za-z0-9-]*[A-Za-z0-9])?$", RegexOptions.IgnoreCase);

        public static Element RenderAsElement(this ComponentElement component)
            => component.ToElement();

        public static string RenderAsHtml<TElement>(this TElement element)
            where TElement : Element
        {
            if(element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var component = element as ComponentElement;

            var renderTree = component != null ? component.ToElement() : element;

            var builder = new StringBuilder();

            RenderNode(renderTree, builder);

            return builder.ToString();
        }

        private static void RenderNode(Element node, StringBuilder builder)
        {
            if(node is null)
            {
                return;
            }

            var textNode = node as TextElement;
            var isTextNode = textNode != null;

            if (isTextNode)
            {
                builder.Append(textNode.Data);
                return;
            }

            if(node is Fragment)
            {
                RenderChildren(node.Children, builder);
                return;
            }
            
            if (!_tagNameCheck.IsMatch(node.Tag))
            {
                throw new InvalidOperationException($"Invalid HTML tag name '{node.Tag}'");
            }

            builder.Append($"<{node.Tag}");

            RenderAttributes(node.Attributes, builder);

            if (node.SelfClosed)
            {
                builder.Append(" />\n");
                return;
            }

            builder.Append(">");

            RenderChildren(node.Children, builder);

            builder.Append($"</{node.Tag}>\n");
        }

        private static void RenderChildren(IEnumerable<Element> children, StringBuilder builder)
        {
            foreach (var child in children ?? Enumerable.Empty<Element>())
            {
                var component = child as ComponentElement;
                // User shouldn't use direct constructor, but we got him covered.
                var actualChild = component != null ? component.ToElement() : child;
                RenderNode(actualChild, builder);
            }
        }

        private static void RenderAttributes(object attributes, StringBuilder builder)
        {
            if(attributes == null)
            {
                return;
            }

            foreach (var attribute in attributes.GetType().GetProperties())
            {
                var name = attribute.Name;
                var value = attribute.GetValue(attributes);

                RenderAttribute(name, value, builder);
            }
        }

        private static void RenderAttribute(string name, object value, StringBuilder builder)
        {
            if(value == null)
            {
                return;
            }

            if(value is bool)
            {
                if ((bool)value)
                {
                    builder.Append($" {name.ToLower()}");
                }
                return;
            }

            if (name.Equals("DataSet", StringComparison.CurrentCultureIgnoreCase))
            {
                foreach(var dataAttribute in value.GetType().GetProperties())
                {
                    var dataName = dataAttribute.Name.ToDashCase();
                    RenderAttribute($"data-{dataName}", dataAttribute.GetValue(value), builder);
                }
                return;
            }

            if (name.Equals("Aria", StringComparison.CurrentCultureIgnoreCase))
            {
                foreach (var dataAttribute in value.GetType().GetProperties())
                {
                    RenderAttribute($"aria-{dataAttribute.Name}", dataAttribute.GetValue(value), builder);
                }
                return;
            }

            if (name.Equals("_"))
            {
                foreach (var dataAttribute in value.GetType().GetProperties())
                {
                    var dataName = dataAttribute.Name.ToDashCase();
                    RenderAttribute(dataName, dataAttribute.GetValue(value), builder);
                }
                return;
            }

            if (name.Equals("HttpEquiv", StringComparison.CurrentCultureIgnoreCase))
            {
                RenderAttribute("http-equiv", value, builder);
                return;
            }

            if (name.Equals("AcceptCharset", StringComparison.CurrentCultureIgnoreCase))
            {
                RenderAttribute("accept-charset", value, builder);
                return;
            }

            var stringValue = value.ToString();

            var sanitizedValue = stringValue.Replace("\"", "&quot;");

            if(value is Enum)
            {
                sanitizedValue = sanitizedValue.ToLower();
            }

            builder.Append(@$" {name.ToLower()}=""{sanitizedValue}""");
        }
    }
}
