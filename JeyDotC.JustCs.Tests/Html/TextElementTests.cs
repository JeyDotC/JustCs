using System;
using JeyDotC.JustCs.Html;
using Xunit;

namespace JeyDotC.JustCs.Tests.Html
{
    public class TextElementTests
    {
       [Fact]
       public void Data_ShouldEscapeCharacters()
        {
            // Arrange
            var maliciousData = "<a>Eveil link</a> <img src=\"evil\" />";

            // Act
            var textElement = new TextElement
            {
                Data = maliciousData,
            };

            // Assert
            Assert.Equal("&lt;a&gt;Eveil link&lt;/a&gt; &lt;img src=\"evil\" /&gt;", textElement.Data);
        }

        [Fact]
        public void Tag_ShouldBeSharpText()
        {
            // Act
            var textElement = new TextElement { };

            // Assert
            Assert.Equal("#Text", textElement.Tag);
        }
    }
}
