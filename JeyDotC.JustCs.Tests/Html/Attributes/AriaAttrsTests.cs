using System;
using System.Collections.Generic;
using JeyDotC.JustCs.Html.Attributes;
using Xunit;

namespace JeyDotC.JustCs.Tests.Html.Attributes
{
    public class AriaAttrsTests
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
            var attrs = new AriaAttrs();

            // Act
            var result = attrs.Equals(other);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_ShouldReturnTrueWhenComparedToSelf()
        {
            // Arrange
            var attrs = new AriaAttrs();

            // Act
            var result = attrs.Equals(attrs);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_ShouldReturnTrueWhenComparedToObjectWithSameProperties()
        {
            // Arrange
            var attrs = new AriaAttrs
            {
                Activedescendant = "active-descendant",
                Checked = TriState.Mixed
            };

            var other = new AriaAttrs
            {
                Activedescendant = "active-descendant",
                Checked = TriState.Mixed
            };

            // Act
            var result = attrs.Equals(other);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_ShouldReturnFalseWhenComparedToObjectWithDifferentProperties()
        {
            // Arrange
            var attrs = new AriaAttrs
            {
                Activedescendant = "active-descendant",
                Checked = TriState.Mixed
            };

            var other = new AriaAttrs
            {
                Activedescendant = "active-descendant",
                Checked = TriState.True
            };

            // Act
            var result = attrs.Equals(other);

            // Assert
            Assert.False(result);
        }
    }
}
