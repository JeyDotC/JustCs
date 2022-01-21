using System;
using JeyDotC.JustCs.Html;
using Xunit;

namespace JeyDotC.JustCs.Tests.Html
{
    public class StylesTests
    {
        [Fact]
        public void From_ShouldGenerateAStylesString()
        {
            // Arrange
            var styles = new
            {
                invalidStyle = (string)null,
                display = "block",
                maxWidth = 100.Percent(),
                minHeight = 300.Px(),
                fontSize = 1.2.Em(),
            };

            // Act
            var generatedStyles = Styles.From(styles);

            // Assert
            Assert.Equal(
                "display: block; max-width: 100%; min-height: 300px; font-size: 1.2em;",
                generatedStyles
            );
        }

        [Fact]
        public void From_ShouldReturnEmptyOnNull()
        {
            // Act
            var generatedStyles = Styles.From(null);

            // Assert
            Assert.Equal(string.Empty, generatedStyles);
        }
    }
}
