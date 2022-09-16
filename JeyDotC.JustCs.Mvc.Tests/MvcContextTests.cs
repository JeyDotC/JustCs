using System;
using Xunit;

namespace JeyDotC.JustCs.Mvc.Tests
{
    public class MvcContextTests
    {
        [Fact]
        public void Context_ShouldThrowWhenNotInitialized()
        {
            // Act
            Action act = () =>
            {
                var context = MvcContext.Context;
            };

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }
    }
}

