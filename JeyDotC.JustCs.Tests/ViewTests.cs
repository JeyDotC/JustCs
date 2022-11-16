using System;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using JeyDotC.JustCs.Testing;
using Xunit;

namespace JeyDotC.JustCs.Tests
{
    public class ViewTests : BaseTest
    {
        [Fact]
        public void View_ShouldRepresentAnHttpResponse()
        {
            // Act
            var view = new View<Div>(new Attrs { Id = "app" }, System.Net.HttpStatusCode.OK)
                .WithHeader("X-Header", "some-value");

            // Assert
            Assert.Equal(new string[] { "some-value" }, view.Headers.GetValues("X-Header"));
            Assert.Equal(System.Net.HttpStatusCode.OK, view.StatusCode);
            Assert.Equivalent(_<Div>(new Attrs { Id = "app" }), view.GetElement().RenderAsHtmlTree());
        }

        [Fact]
        public void View_ShoulThrowWhenProvidingWrongAttributeTypeToStronglyTypedComponent()
        {
            // Arrange
            var view = new View<ElementFromParams>(new Attrs { Id = "app" });
            var component = view.GetElement() as ElementFromParams;

            // Act
            Action action = () => component.RenderAsElement();

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void View_ShoulThrowWhenProvidingNullToStronglyTypedComponent()
        {
            // Arrange
            var view = new View<ElementFromParams>();
            var component = view.GetElement() as ElementFromParams;

            // Act
            Action action = () => component.RenderAsElement();

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}
