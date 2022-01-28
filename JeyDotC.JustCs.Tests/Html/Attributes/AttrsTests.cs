using System;
using System.Collections.Generic;
using JeyDotC.JustCs.Html.Attributes;
using Xunit;

namespace JeyDotC.JustCs.Tests.Html.Attributes
{
    class SomeObject { }

    public class AttrsTests
    {

        public static IEnumerable<object[]> EqualsSubjects()
        {
            yield return new object[] { null };
            yield return new object[] { new SomeObject() };
        }

        [Theory]
        [MemberData(nameof(EqualsSubjects))]
        public void Equals_ShouldReturnFalseWhenOtherObjectIsNullOrNotAnAttrs(object other)
        {
            // Arrange
            var attrs = new Attrs();

            // Act
            var result = attrs.Equals(other);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_ShouldReturnTrueWhenComparedToSelf()
        {
            // Arrange
            var attrs = new Attrs();

            // Act
            var result = attrs.Equals(attrs);

            // Assert
            Assert.True(result);
        }
    }
}
