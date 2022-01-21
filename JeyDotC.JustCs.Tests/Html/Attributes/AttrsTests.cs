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
        public void GetHashCode_ShouldReturnCodeBasedOnSetProperties()
        {
            // Arrange
            var className = "some-class";
            var dir = DirValues.Ltr;
            var expectedHashCode = className.GetHashCode() + dir.GetHashCode();
            var attrs = new Attrs
            {
                Class = className,
                Dir = dir,
            };

            // Act
            var actualHashCode = attrs.GetHashCode();
            var secondAttempt = attrs.GetHashCode();

            // Assert
            Assert.Equal(expectedHashCode, actualHashCode);
            Assert.Equal(expectedHashCode, secondAttempt);
        }
    }
}
