using System;
using JeyDotC.JustCs.Configuration;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using JeyDotC.JustCs.Mvc.Components;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace JeyDotC.JustCs.Mvc.Tests.Components
{
    public class AntiForgeryTokenTests : IDisposable
    {
        public AntiForgeryTokenTests()
        {
            JustCsSettings.AttributeDecorators.Add(new DefaultPropsDecorator());
        }

        [Fact]
        public void Render_ShouldProduceHiddenInputWithAntiforgeryToken()
        {
            // Arrange
            var httpContextMock = new Mock<HttpContext>();
            var antiForgeryMock = new Mock<IAntiforgery>();

            var antiForgeryTokenSet = new AntiforgeryTokenSet(
                    requestToken: "request-token",
                    cookieToken: "cookie-token",
                    formFieldName: "__RequestToken",
                    headerName: "X-TOKEN"
                );

            antiForgeryMock.Setup(a => a.GetAndStoreTokens(It.IsAny<HttpContext>())).Returns(antiForgeryTokenSet);


            // Act
            var antiForgeryTokenInput = new AntiForgeryToken
            {
                Attributes = new AntiForgeryTokenProps
                {
                    AntiForgery = antiForgeryMock.Object,
                    HttpContext = httpContextMock.Object,
                }
            }.RenderAsElement();

            // Assert
            Assert.Equal("input", antiForgeryTokenInput.Tag);
            Assert.Equal(typeof(Input), antiForgeryTokenInput.GetType());
            Assert.Equal(new Attrs
            {
                Type = "hidden",
                Name = antiForgeryTokenSet.FormFieldName,
                Value = antiForgeryTokenSet.RequestToken,
            }, antiForgeryTokenInput.Attributes);
        }

        class DummyForm : ComponentElement
        {
            protected override Element Render(IElementAttributes attributes)
                => _<AntiForgeryToken>();
        }

        [Fact]
        public void Render_ShouldUseTheDefaultAntiForgeryTokenAttributes()
        {
            // Arrange
            var httpContextMock = new Mock<HttpContext>();
            var antiForgeryMock = new Mock<IAntiforgery>();

            var antiForgeryTokenSet = new AntiforgeryTokenSet(
                    requestToken: "request-token",
                    cookieToken: "cookie-token",
                    formFieldName: "__RequestToken",
                    headerName: "X-TOKEN"
                );

            antiForgeryMock.Setup(a => a.GetAndStoreTokens(It.IsAny<HttpContext>())).Returns(antiForgeryTokenSet);

            JustCsSettings.AttributeDecorators.Add((attributes, componentType) =>
            {
                if (attributes is AntiForgeryTokenProps)
                {
                    return new AntiForgeryTokenProps
                    {
                        AntiForgery = antiForgeryMock.Object,
                        HttpContext = httpContextMock.Object,
                    };
                }
                return attributes;
            });

            var form = new DummyForm();

            // Act
            var element = form.RenderAsElement();

            // Assert
            Assert.Equal("input", element.Tag);
            Assert.Equal(new Attrs
            {
                Type = "hidden",
                Name = "__RequestToken",
                Value = "request-token",
            }, element.Attributes);
        }

        public void Dispose()
        {
            JustCsSettings.AttributeDecorators.Clear();
        }
    }
}

