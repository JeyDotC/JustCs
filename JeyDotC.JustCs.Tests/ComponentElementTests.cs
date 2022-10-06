using System;
using System.Collections;
using System.Collections.Generic;
using JeyDotC.JustCs.Configuration;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using Xunit;

namespace JeyDotC.JustCs.Tests
{
    class DummyDecorator : IAttributesDecorator
    {
        public IElementAttributes Decorate(IElementAttributes attributes) => attributes;
    }

    struct MyComponentProps : IElementAttributes { }
    record PropsWithValues : IElementAttributes {
        public string Value { get; init; }
    }

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

    class ElementWithBadProps : ComponentElement
    {
        protected override Element Render(IElementAttributes props)
            => _<ElementFromIEnumerableWithAttributes>(new Attrs { });
    }

    class ElementWithNullProps : ComponentElement
    {
        protected override Element Render(IElementAttributes props)
            => _<ElementFromIEnumerableWithAttributes>();
    }

    class ElementWithDefaultProps : ComponentElement<PropsWithValues>
    {
        public static PropsWithValues DefaultAttributes => new PropsWithValues
        {
            Value = "100",
        };

        protected override Element Render(PropsWithValues props)
            => _<Div>(new Attrs { Id = props.Value });
    }

    class RenderElementWithDefaultProps : ComponentElement
    {
        protected override Element Render(IElementAttributes attributes)
            => _<ElementWithDefaultProps>();
    }

    public class ComponentElementTests : IDisposable
    {

        public ComponentElementTests()
        {
            JustCsSettings.AttributeDecorators.Add(new DummyDecorator());
        }



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

            yield return new object[] {
                new RenderElementWithDefaultProps{}, // Component
                nameof(RenderElementWithDefaultProps), // Expected Tag
                typeof(Div), // Expected Element
                new Attrs { Id = "100" }, // Expected Attributes
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

        [Fact]
        public void ToElement_ShouldThrowWhenStronglyTypedRecivesWrongType()
        {
            // Arrange
            var elementWithBadProps = new ElementWithBadProps();

            // Act
            Action action = () => elementWithBadProps.RenderAsElement();

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void ToElement_ShouldThrowWhenStronglyTypedRecivesNull()
        {
            // Arrange
            var elementWithBadProps = new ElementWithNullProps();

            // Act
            Action action = () => elementWithBadProps.RenderAsElement();

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        public void Dispose()
        {
            JustCsSettings.AttributeDecorators.Clear();
        }
    }
}
