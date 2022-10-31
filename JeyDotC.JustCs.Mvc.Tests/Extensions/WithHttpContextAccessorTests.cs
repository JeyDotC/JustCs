using System;
using System.Reflection;
using JeyDotC.JustCs.Configuration.Decorators;
using JeyDotC.JustCs.Mvc.Extensions;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace JeyDotC.JustCs.Mvc.Tests.Extensions
{
    public class WithHttpContextAccessorTests
    {
        [Fact]
        public void ResolveHttpContext_ShouldReturnHttpContextWhenRequestedAndAvailable()
        {
            // Arrange
            var serviceProviderMock = new Mock<IServiceProvider>();
            var httpAccessorMock = new Mock<IHttpContextAccessor>();
            var httpContextMock = new Mock<HttpContext>();
            var propertyInfoMock = new Mock<PropertyInfo>();
            propertyInfoMock.SetupGet(p => p.PropertyType).Returns(typeof(HttpContext));

            serviceProviderMock.Setup(p => p.GetService(It.IsAny<Type>())).Returns(httpAccessorMock.Object);
            httpAccessorMock.SetupGet(a => a.HttpContext).Returns(httpContextMock.Object);

            var context = new ResolutionContext
            {
                InjectInfo = new InjectAttribute(),
                Property = propertyInfoMock.Object,
                ServiceProvider = serviceProviderMock.Object,
                ComponentType = typeof(ComponentElement),
            };

            // Act
            var result = ServiceProviderDecoratorExtensions.ResolveHttpContext(context);

            // Assert
            Assert.IsAssignableFrom<HttpContext>(result);
        }

        [Fact]
        public void ResolveHttpContext_ShouldReturnNullWhenContextNotRequested()
        {
            // Arrange
            var serviceProviderMock = new Mock<IServiceProvider>();
            var propertyInfoMock = new Mock<PropertyInfo>();
            propertyInfoMock.SetupGet(p => p.PropertyType).Returns(typeof(WithHttpContextAccessorTests));

            var context = new ResolutionContext
            {
                InjectInfo = new InjectAttribute(),
                Property = propertyInfoMock.Object,
                ServiceProvider = serviceProviderMock.Object,
            };

            // Act
            var result = ServiceProviderDecoratorExtensions.ResolveHttpContext(context);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ResolveHttpContext_ShouldThrowWhenHttpContextAccessorIsNotAvailable()
        {
            // Arrange
            var serviceProviderMock = new Mock<IServiceProvider>();
            var propertyInfoMock = new Mock<PropertyInfo>();

            propertyInfoMock.SetupGet(p => p.PropertyType).Returns(typeof(HttpContext));
            serviceProviderMock.Setup(p => p.GetService(It.IsAny<Type>())).Returns(null);

            var context = new ResolutionContext
            {
                InjectInfo = new InjectAttribute(),
                Property = propertyInfoMock.Object,
                ServiceProvider = serviceProviderMock.Object,
            };

            // Act
            var act = () => ServiceProviderDecoratorExtensions.ResolveHttpContext(context);

            // Assert
            var exception = Assert.Throws<InvalidOperationException>(act);
            Assert.StartsWith("HttpContext is not available", exception.Message);
        }
    }
}

