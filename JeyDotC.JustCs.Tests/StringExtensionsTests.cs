using System;
using Xunit;

namespace JeyDotC.JustCs.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ToDashCase_ShouldReturnEmptyStringWhenNullGiven()
        {
            // Arrange
            string nullString = null;

            // Act
            var resultString = nullString.ToDashCase();

            // Assert
            Assert.Equal(string.Empty, resultString);
        }
    }
}
