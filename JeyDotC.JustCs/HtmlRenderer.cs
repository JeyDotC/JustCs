﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Annotations;

namespace JeyDotC.JustCs
{
    public static class HtmlRenderer
    {
        private static readonly Regex _tagNameCheck = new Regex("^[A-Za-z]([A-Za-z0-9-]*[A-Za-z0-9])?$", RegexOptions.IgnoreCase);

        /// <summary>
        /// Invokes this component's Render method with its current Attributes.
        /// This method doesn't affect the children which only get instantiated
        /// (not rendered). This method is intended for testing and debugging
        /// only.
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public static Element RenderAsElement(this ComponentElement component)
            => component.ToElement();

        public static string RenderAsHtml<TElement>(this TElement element)
            where TElement : Element
        {
            if (element == null)
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
            if (node is null)
            {
                return;
            }

            var textNode = node as TextElement;

            if (textNode is not null)
            {
                builder.Append(textNode.Data);
                return;
            }

            if (node is Fragment)
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

        private static void RenderAttributes(object? attributes, StringBuilder builder)
        {
            if (attributes is null)
            {
                return;
            }

            var attributesDictionary = GenerateAttributesDictionary(attributes);

            RenderAttributesDictionary(attributesDictionary, builder);
        }

        private static AttrAttribute GetAttrMetadata(this PropertyInfo property, NameTransform defaultTransform = NameTransform.LowerCase)
            => property.GetCustomAttributes(typeof(AttrAttribute), true).FirstOrDefault() as AttrAttribute ?? new AttrAttribute(defaultTransform);

        private static IDictionary<string, object> GenerateAttributesDictionary(object attributes)
        {
            var attributesDictionary = new Dictionary<string, object>();

            foreach (var attribute in attributes.GetType().GetProperties())
            {
                var name = attribute.Name;
                var value = attribute.GetValue(attributes);
                var attrMetadata = attribute.GetAttrMetadata();

                ProcessAttribute(name, value, attrMetadata, attributesDictionary);
            }

            return attributesDictionary;
        }

        private static void ProcessAttribute(string name, object? value, AttrAttribute attributeMetadata, IDictionary<string, object> attributesDictionary)
        {
            if (value is null)
            {
                return;
            }

            if (value is bool && (bool)value == false)
            {
                return;
            }

            var valueAsTuple = value as ITuple;
            if(valueAsTuple is not null && valueAsTuple.Length == 2 )
            {
                var nameTransform = valueAsTuple[1];

                ProcessAttribute(
                    name,
                    valueAsTuple[0],
                    new AttrAttribute(
                        nameTransform is not null
                        ? (NameTransform)nameTransform
                        : default(NameTransform)
                    ),
                    attributesDictionary
                );
                return;
            }

            if (name.Equals("DataSet", StringComparison.CurrentCultureIgnoreCase))
            {
                foreach (var dataAttribute in value.GetType().GetProperties())
                {
                    var dataName = $"data-{dataAttribute.Name}";
                    ProcessAttribute(
                        dataName, 
                        dataAttribute.GetValue(value), 
                        dataAttribute.GetAttrMetadata(NameTransform.DashCase), 
                        attributesDictionary
                    );
                }
                return;
            }

            if (name.Equals("Aria", StringComparison.CurrentCultureIgnoreCase))
            {
                foreach (var dataAttribute in value.GetType().GetProperties())
                {
                    var ariaName = $"aria-{dataAttribute.Name.ToLower()}";
                    ProcessAttribute(
                        ariaName, 
                        dataAttribute.GetValue(value), 
                        dataAttribute.GetAttrMetadata(),
                        attributesDictionary
                    );
                }
                return;
            }

            if (name.Equals("_"))
            {
                foreach (var dataAttribute in value.GetType().GetProperties())
                {
                    ProcessAttribute(
                        dataAttribute.Name,
                        dataAttribute.GetValue(value),
                        dataAttribute.GetAttrMetadata(),
                        attributesDictionary
                    );
                }
                return;
            }

            name = (attributeMetadata.NameTransform switch
            {
                NameTransform.DashCase => name.ToDashCase(),
               _ => name
            }).ToLower();

            attributesDictionary[name] = value;
        }

        private static void RenderAttributesDictionary(IDictionary<string, object> attributesDictionary, StringBuilder builder)
        {

            foreach (var entry in attributesDictionary)
            {
                var (name, value) = entry;

                if(value is bool)
                {
                    builder.Append($" {name}");
                    continue;
                }

                var stringValue = value.ToString() ?? string.Empty;

                var sanitizedValue = stringValue.Replace("\"", "&quot;");

                if (value is Enum)
                {
                    sanitizedValue = sanitizedValue.ToLower();
                }

                builder.Append(@$" {name}=""{sanitizedValue}""");
            }
        }
    }
}
