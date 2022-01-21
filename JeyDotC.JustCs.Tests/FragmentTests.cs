using System;
using Xunit;

namespace JeyDotC.JustCs.Tests
{
    public class FragmentTests
    {
        [Fact]
        public void Tag_ShouldBeEmpty()
        {
            // Act
            var fragment = new Fragment { };

            // Assert
            Assert.Equal("", fragment.Tag);
        }
    }
}
