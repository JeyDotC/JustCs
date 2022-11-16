using System;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Testing;
using Xunit;

namespace JeyDotC.JustCs.Tests
{
    public class FragmentTests : JustCsTest
    {
        [Fact]
        public void Tag_ShouldBeEmpty()
        {
            // Act
            var fragment = new Fragment { };

            // Assert
            Assert.Equal("", fragment.Tag);
        }

        [Fact]
        public void Render_ChildrenShouldBeRenderedDirectlyIntoParent()
        {
            // Arrange
            var fragment = new Fragment
            {
                Children = new Element[]
                {
                    _<Span>("Hello"),
                    _<Span>("World")
                }
            };

            // Act
            var html = _<Div>(fragment).RenderAsHtmlTree();

            // Assert
            Assert.Equivalent(
                _<Div>(
                    _<Span>("Hello"),
                    _<Span>("World")
                ),
                html
            );
        }
    }
}
