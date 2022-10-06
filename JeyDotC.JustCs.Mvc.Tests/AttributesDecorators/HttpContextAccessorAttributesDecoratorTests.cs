using System;
using System.Collections.Generic;
using System.Linq;
using JeyDotC.JustCs.Configuration;
using JeyDotC.JustCs.Html.Attributes;
using JeyDotC.JustCs.Mvc.AttributesDecorators;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace JeyDotC.JustCs.Mvc.Tests.AttributesDecorators
{
#nullable enable
    public sealed class HttpContextAccessorAttributesDecoratorTests
    {
        private static Mock<IServiceProvider> _serviceProviderMock = new Mock<IServiceProvider>();
        private static Mock<IHttpContextAccessor> _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        private static Mock<HttpContext> _httpContextMock = new Mock<HttpContext>();

        static HttpContextAccessorAttributesDecoratorTests()
        {
            _serviceProviderMock.Setup(s => s.GetService(It.IsAny<Type>()))
                .Returns(_httpContextAccessorMock.Object);

            _httpContextAccessorMock.SetupGet(a => a.HttpContext)
                .Returns(_httpContextMock.Object);
        }

        record ShouldRemainTheSame : IElementAttributes
        {
            public int IntProp { get; init; }

            [Inject]
            public int IntInjectableProp { get; init; }

            public HttpContext? ShouldRemainNullBecauseMissingInject { get; init; }
        }

        record ShouldInjectHttpContext : IElementAttributes
        {
            [Inject]
            public HttpContext? HttpContext { get; init; }
        }

        public static IEnumerable<object?[]> TestData()
        {
            yield return new object?[] { null, null };

            yield return new object?[] { new ShouldRemainTheSame(), new ShouldRemainTheSame() };

            yield return new object?[] { new ShouldInjectHttpContext(), new ShouldInjectHttpContext { HttpContext = _httpContextMock.Object } };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Decorate_ShouldFillHttpContextWhenApplicable(
            IElementAttributes? sourceAttributes,
            IElementAttributes? expectedAttributes
            )
        {
            // Arrange
            var decorator = new HttpContextAccessorAttributesDecorator(_serviceProviderMock.Object);

            // Act
            var actualAttributes = decorator.Decorate(sourceAttributes);

            // Assert
            Assert.Equal(expectedAttributes, actualAttributes);
        }

        [Fact]
        public void Decorate_ShouldThrowExceptionWhenAccessorIsNotConfigured()
        {
            // Arrange
            var serviceProviderMock = new Mock<IServiceProvider>();
            var decorator = new HttpContextAccessorAttributesDecorator(serviceProviderMock.Object);

            // Act
            Action act = () => decorator.Decorate(new ShouldInjectHttpContext());

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }
    }
}

