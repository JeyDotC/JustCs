﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JeyDotC.JustCs.Configuration;
using JeyDotC.JustCs.Configuration.Decorators;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using Moq;
using Xunit;

namespace JeyDotC.JustCs.Tests.Configuration.Decorators
{
#nullable enable
    public class ServiceProviderAttributesDecoratorTests
    {
        record PropsWithInjectableAttrs : IElementAttributes
        {
            public string? NotInjectable { get; init; }

            [Inject]
            public string? Service1 { get; init; }

            [Inject]
            public int? IntValue { get; init; }

            [Inject]
            public float? FloatValue { get; init; }

            [Inject]
            public bool? NotFoundService { get; init; }
        }

        public static IEnumerable<object?[]> TestCases()
        {
            yield return new object?[] { null, null };
            yield return new object?[] {
                new PropsWithInjectableAttrs(),
                new PropsWithInjectableAttrs
                {
                    Service1 = "Service 1",
                    IntValue = 42,
                    FloatValue = 600f
                }
            };
        }

        private static Mock<IServiceProvider> _serviceProviderMock = new Mock<IServiceProvider>();

        static ServiceProviderAttributesDecoratorTests()
        {
            _serviceProviderMock
                .Setup(p => p.GetService(It.Is<Type>(t => t == typeof(string))))
                .Returns("Service 1");

            _serviceProviderMock
                .Setup(p => p.GetService(It.Is<Type>(t => t == typeof(int?))))
                .Returns(42);

            _serviceProviderMock
                .Setup(p => p.GetService(It.Is<Type>(t => t == typeof(float?))))
                .Returns(600f);
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void Decorate_ShouldSetInjectableValuesWhenAvailable(
            IElementAttributes? receivedAttributes,
            IElementAttributes? expectedResultAttributes
        )
        {
            // Arrange
            var decorator = new ServiceProviderAttributesDecorator(_serviceProviderMock.Object);

            // Act
            var actualResultAttributes = decorator.Decorate(new AttributesContext
            {
                Attributes = receivedAttributes,
                ElementType = typeof(Div),
            });

            // Assert
            Assert.Equal(expectedResultAttributes, actualResultAttributes);
        }

        [ExcludeFromCodeCoverage]
        record PropsWithRequiredInjectableAttrs : IElementAttributes
        {
            [Inject(Required = true)]
            public int RequiredProp { get; init; }
        }

        [Fact]
        public void Decorate_ShouldThrowWhenPropertycleIsRequiredButNotResolved()
        {
            // Arrange
            var serviceProviderMock = new Mock<IServiceProvider>();
            var decorator = new ServiceProviderAttributesDecorator(serviceProviderMock.Object);


            // Act
            var act = () => decorator.Decorate(new AttributesContext
            {
                Attributes = new PropsWithRequiredInjectableAttrs(),
                ElementType = typeof(Div)
            });

            // Assert
            var exception = Assert.Throws<InvalidOperationException>(act);
            Assert.StartsWith("Div attribute RequiredProp is required", exception.Message);
        }
    }
}

