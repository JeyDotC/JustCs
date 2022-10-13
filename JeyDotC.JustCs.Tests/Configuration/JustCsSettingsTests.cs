using System;
using System.Diagnostics.CodeAnalysis;
using JeyDotC.JustCs.Configuration;
using Xunit;

namespace JeyDotC.JustCs.Tests.Configuration
{
    public class JustCsSettingsTests : IDisposable
    {
        [Fact]
        public void Add_NullShouldReturnFalse()
        {
            // Act
            var result = JustCsSettings.AttributeDecorators.Add(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Add_ShouldAddItemsOfTypeOnlyOnce()
        {
            // Act
            var firstAdd = JustCsSettings.AttributeDecorators.Add(new DefaultPropsDecorator());
            var secondAdd = JustCsSettings.AttributeDecorators.Add(new DefaultPropsDecorator());
            var thirdAdd = JustCsSettings.AttributeDecorators.Add(new DefaultPropsDecorator());

            // Assert
            Assert.True(firstAdd);
            Assert.False(secondAdd);
            Assert.False(thirdAdd);
        }

        [Fact]
        public void Add_ShouldAddMultipleDelegateDecorators()
        {
            // Arrange
            DecorateImplementation implementation1 = [ExcludeFromCodeCoverage] (ctx) => ctx.Attributes;
            DecorateImplementation implementation2 = [ExcludeFromCodeCoverage] (ctx) => ctx.Attributes;
            DecorateImplementation implementation3 = [ExcludeFromCodeCoverage] (ctx) => ctx.Attributes;
            DecorateImplementation implementation4 = [ExcludeFromCodeCoverage] (ctx) => ctx.Attributes;

            // Act
            var firstAdd = JustCsSettings.AttributeDecorators.Add(implementation1);
            var secondAdd = JustCsSettings.AttributeDecorators.Add(new DelegateAttributesDecorator(implementation2));
            var thirdAdd = JustCsSettings.AttributeDecorators.Add(implementation3);
            var fourthAdd = JustCsSettings.AttributeDecorators.Add(implementation4);

            // Assert
            Assert.True(firstAdd);
            Assert.True(secondAdd);
            Assert.True(thirdAdd);
            Assert.True(fourthAdd);
        }

        public void Dispose()
        {
            JustCsSettings.AttributeDecorators.Clear();
        }
    }
}

