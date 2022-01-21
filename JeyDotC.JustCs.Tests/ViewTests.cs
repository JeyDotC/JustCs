using System;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using Xunit;

namespace JeyDotC.JustCs.Tests
{
    public class ViewTests
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
            Assert.Equal("<div id=\"app\"></div>\n", view.GetElement().RenderAsHtml());
        }
    }
}
