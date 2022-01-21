using System;
using System.Collections;
using System.Collections.Generic;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using Xunit;

namespace JeyDotC.JustCs.Tests
{
    struct MyComponentProps : IElementAttributes { }

    class FragmentFromParams : ComponentElement<MyComponentProps>
    {
        protected override Element Render(MyComponentProps props)
            => _(
                _<A>(new Attrs { Href = "/index" }),
                _<A>(new Attrs { Href = "/about" })
            );
    }

    class FragmentFromIEnumerable : ComponentElement<MyComponentProps>
    {
        protected override Element Render(MyComponentProps props)
        => _(
                new List<Element>
                {
                    _<A>(new Attrs { Href = "/index" }),
                    _<A>(new Attrs { Href = "/about" })
                }
            );
    }

    class ElementFromParams : ComponentElement<MyComponentProps>
    {
        protected override Element Render(MyComponentProps props)
        => _<Div>(
                _<A>(new Attrs { Href = "/index" }),
                _<A>(new Attrs { Href = "/about" })
            );
    }

    class ElementFromIEnumerable : ComponentElement<MyComponentProps>
    {
        protected override Element Render(MyComponentProps props)
        => _<Div>(
                new List<Element>
                {
                    _<A>(new Attrs { Href = "/index" }),
                    _<A>(new Attrs { Href = "/about" })
                }
            );
    }

    class ElementFromParamsWithAttributes : ComponentElement<MyComponentProps>
    {
        protected override Element Render(MyComponentProps props)
        => _<Div>(new Attrs { Id = "some-div" },
                _<A>(new Attrs { Href = "/index" }),
                _<A>(new Attrs { Href = "/about" })
            );
    }

    class ElementFromIEnumerableWithAttributes : ComponentElement<MyComponentProps>
    {
        protected override Element Render(MyComponentProps props)
        => _<Div>( new Attrs { Id = "some-div" },
                new List<Element>
                {
                    _<A>(new Attrs { Href = "/index" }),
                    _<A>(new Attrs { Href = "/about" })
                }
            );
    }

    class ElementFromComponent : ComponentElement
    {
        protected override Element Render(IElementAttributes attributes)
         => _<ElementFromParams>(new MyComponentProps());
    }

    public class ComponentElementTests
    {
        public static IEnumerable<object[]> TestedComponents()
        {
            yield return new object[] {
                new FragmentFromParams{ Attributes = new MyComponentProps() }, // Component
                nameof(FragmentFromParams), // Expected Tag
                typeof(Fragment), // Expected Element
                null, // Expected Attributes
            };

            yield return new object[] {
                new FragmentFromIEnumerable{ Attributes = new MyComponentProps() }, // Component
                nameof(FragmentFromIEnumerable), // Expected Tag
                typeof(Fragment), // Expected Element
                null, // Expected Attributes
            };

            yield return new object[] {
                new ElementFromParams{ Attributes = new MyComponentProps() }, // Component
                nameof(ElementFromParams), // Expected Tag
                typeof(Div), // Expected Element
                null, // Expected Attributes
            };

            yield return new object[] {
                new ElementFromIEnumerable{ Attributes = new MyComponentProps() }, // Component
                nameof(ElementFromIEnumerable), // Expected Tag
                typeof(Div), // Expected Element
                null, // Expected Attributes
            };

            yield return new object[] {
                new ElementFromParamsWithAttributes{ Attributes = new MyComponentProps() }, // Component
                nameof(ElementFromParamsWithAttributes), // Expected Tag
                typeof(Div), // Expected Element
                new Attrs { Id = "some-div" }, // Expected Attributes
            };

            yield return new object[] {
                new ElementFromIEnumerableWithAttributes{ Attributes = new MyComponentProps() }, // Component
                nameof(ElementFromIEnumerableWithAttributes), // Expected Tag
                typeof(Div), // Expected Element
                new Attrs { Id = "some-div" }, // Expected Attributes
            };

            yield return new object[] {
                new ElementFromComponent{}, // Component
                nameof(ElementFromComponent), // Expected Tag
                typeof(Div), // Expected Element
                null, // Expected Attributes
            };
        }

        [Theory]
        [MemberData(nameof(TestedComponents))]
        public void ToElement_ShouldProduceElement(ComponentElement component, string expectedTag, Type expectedElement, IElementAttributes expectedAttributes)
        {
            // Act
            var element = component.RenderAsElement();

            // Assert
            Assert.Equal(expectedTag, component.Tag);
            Assert.Equal(expectedElement, element.GetType());
            Assert.Equal(expectedAttributes, element.Attributes);
        }
    }
}
