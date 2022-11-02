using System;
using System.Reflection;
using JeyDotC.JustCs.Configuration.Decorators;
using Moq;
using Xunit;

namespace JeyDotC.JustCs.Tests.Configuration.Decorators
{
    public class ResolutionContextTests
    {
        private ResolutionContext CreateResolutionContext()
            => new ResolutionContext
            {
                ServiceProvider = new Mock<IServiceProvider>().Object,
                Property = new Mock<PropertyInfo>().Object,
                InjectInfo = new InjectAttribute(),
                ComponentType = typeof(ComponentElement),
            };

        [Fact]
        public void Deconstruct_ShouldReturnServiceProviderAndProperty()
        {
            // Arrange
            var resolutionContext = CreateResolutionContext();

            // Act
            var (serviceProvider, property) = resolutionContext;

            // Assert
            Assert.IsAssignableFrom<IServiceProvider>(serviceProvider);
            Assert.IsAssignableFrom<PropertyInfo>(property);
        }

        [Fact]
        public void Deconstruct_ShouldReturnServiceProviderAndPropertyAndInjectAttribute()
        {
            // Arrange
            var resolutionContext = CreateResolutionContext();

            // Act
            var (serviceProvider, property, inject) = resolutionContext;

            // Assert
            Assert.IsAssignableFrom<IServiceProvider>(serviceProvider);
            Assert.IsAssignableFrom<PropertyInfo>(property);
            Assert.IsAssignableFrom<InjectAttribute>(inject);
        }

        [Fact]
        public void Deconstruct_ShouldReturnAllProperties()
        {
            // Arrange
            var resolutionContext = CreateResolutionContext();

            // Act
            var (serviceProvider, property, inject, componentType) = resolutionContext;

            // Assert
            Assert.IsAssignableFrom<IServiceProvider>(serviceProvider);
            Assert.IsAssignableFrom<PropertyInfo>(property);
            Assert.IsAssignableFrom<InjectAttribute>(inject);
            Assert.IsAssignableFrom<Type>(componentType);
        }
    }
}

