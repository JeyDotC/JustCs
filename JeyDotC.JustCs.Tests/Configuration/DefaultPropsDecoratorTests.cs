using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JeyDotC.JustCs.Configuration;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using Xunit;

namespace JeyDotC.JustCs.Tests.Configuration
{
#nullable enable
    public class DefaultPropsDecoratorTests
    {
        [Theory]
        [MemberData(nameof(DecorateData))]
        public void Decorate_ShouldAlterThegivenAttributes(IElementAttributes? providedAttributes, Type elementType, IElementAttributes? expectedAttributes)
        {
            // Arrange
            var defaultPropsDecorator = new DefaultPropsDecorator();

            // Act
            var actualAttributes = defaultPropsDecorator.Decorate(new AttributesContext { Attributes = providedAttributes, ElementType = elementType });

            // Assert
            Assert.Equal(expectedAttributes, actualAttributes);
        }

        [Fact]
        public void Decorate_ShouldFailIfDefaultPropHasNoDefaultConstructor()
        {
            // Arrange
            var defaultPropsDecorator = new DefaultPropsDecorator();

            // Act
            Action act = () => defaultPropsDecorator.Decorate(new AttributesContext { Attributes = null, ElementType = typeof(ComponentWithInvalidDefaults) });

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        class AttrWithoutDefaultConstructor : IElementAttributes
        {
            private readonly string _someProp;

            public AttrWithoutDefaultConstructor(string someProp)
            {
                _someProp = someProp;
            }
        }

        class ComponentWithInvalidDefaults : ComponentElement
        {
            public static AttrWithoutDefaultConstructor DefaultAttributes => new AttrWithoutDefaultConstructor("Foo");

            [ExcludeFromCodeCoverage]
            protected override Element Render(IElementAttributes attributes) => throw new NotImplementedException();
        }

        record PropsWithMoreValues : PropsWithValues
        {
            public string? ExtraValue { get; init; }
        }

        public static IEnumerable<object?[]> DecorateData()
        {
            yield return new object?[] { null, typeof(Div), null };
            yield return new object?[] { new Attrs { }, typeof(Div), new Attrs { } };
            yield return new object?[] { null, typeof(ElementWithDefaultProps), new PropsWithValues { Value = "100" } };
            yield return new object?[] { new PropsWithValues { }, typeof(ElementWithDefaultProps), new PropsWithValues { Value = "100" } };
            yield return new object?[] { new Attrs { }, typeof(ElementWithDefaultProps), new Attrs { } };
            yield return new object?[] { new PropsWithValues { Value = "200" }, typeof(ElementWithDefaultProps), new PropsWithValues { Value = "200" } };
            yield return new object?[] { new PropsWithMoreValues { }, typeof(ElementWithDefaultProps), new PropsWithMoreValues { Value = "100" } };
            yield return new object?[] { new PropsWithMoreValues { ExtraValue = "200" }, typeof(ElementWithDefaultProps), new PropsWithMoreValues { Value = "100", ExtraValue = "200" } };
        }
    }
}

