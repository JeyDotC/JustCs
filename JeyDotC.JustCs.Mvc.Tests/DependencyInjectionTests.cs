using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace JeyDotC.JustCs.Mvc.Tests
{
    public class DependencyInjectionTests
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
    }
}
