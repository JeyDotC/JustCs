using System;
using System.Linq;
using JeyDotC.JustCs.Configuration;
using JeyDotC.JustCs.Mvc.AttributesDecorators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace JeyDotC.JustCs.Mvc.Tests
{
    public class DependencyInjectionTests : IDisposable
    {
        [Fact]
        public void WithJustCs_ShouldInsertTheHtmlOutputFormatterIntoMvcOptions()
        {
            // Arrange
            var mvcOptions = new MvcOptions();

            // Act
            mvcOptions.WithJustCs();

            // Assert
            Assert.IsType<HtmlOutputFormatter>(mvcOptions.OutputFormatters[0]);
        }

        [Fact]
        public void UseJustCs_ShouldAddTheNecessaryAttributesDecorators()
        {
            // Arrange
            var applicationBuilderMock = new Mock<IApplicationBuilder>();
            var applicationServicesMock = new Mock<IServiceProvider>();

            applicationBuilderMock.SetupGet(app => app.ApplicationServices)
                .Returns(applicationServicesMock.Object);

            var app = applicationBuilderMock.Object;

            // Act
            app.UseJustCs();

            // Assert
            var decoratorsList = JustCsSettings.AttributeDecorators.ToArray();
            Assert.Equal(3, decoratorsList.Length);
            Assert.IsType<DefaultPropsDecorator>(decoratorsList[0]);
            Assert.IsType<ServiceProviderAttributesDecorator>(decoratorsList[1]);
            Assert.IsType<HttpContextAccessorAttributesDecorator>(decoratorsList[2]);
        }

        public void Dispose()
        {
            JustCsSettings.AttributeDecorators.Clear();
        }
    }
}
