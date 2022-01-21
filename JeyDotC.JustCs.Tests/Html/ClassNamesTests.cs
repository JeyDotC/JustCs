using System;
using System.Collections.Generic;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using Xunit;

namespace JeyDotC.JustCs.Tests.Html
{
    public class ClassNamesTests
    {
        public static IEnumerable<object[]> ClassNameSpecs()
        {
            yield return new object[] { null, string.Empty };
            yield return new object[] { "class-name", "class-name" };
            yield return new object[] { 500, "500" };
            yield return new object[] { DirValues.Ltr, "Ltr" };
            yield return new object[] { ("class-name", true), "class-name" };
            yield return new object[] { ("class-name", false), string.Empty };
            yield return new object[] { ( new { shouldAppear = true, shouldNotAppear = false  }, PropertyAsClassBehavior.AsIs), "shouldAppear" };
            yield return new object[] { (new { shouldAppear = true, shouldNotAppear = false }, PropertyAsClassBehavior.TransformToDashCase), "should-appear" };
            yield return new object[] { new { shouldAppear = true, shouldNotAppear = false }.AsIs(), "shouldAppear" };
            yield return new object[] { new { shouldAppear = true, shouldNotAppear = false }.TransformToDashCase(), "should-appear" };
            yield return new object[] { new { shouldAppear = true, shouldNotAppear = false }, "should-appear" };
        }

        [Theory]
        [MemberData(nameof(ClassNameSpecs))]
        public void From_ShouldTransformTheGivenSpecIntoValidClassName(object classSpec, string expectedClassNames)
        {
            // Act
            var actualClassNames = ClassNames.From(classSpec);

            // Assert
            Assert.Equal(expectedClassNames, actualClassNames);
        }

        [Fact]
        public void From_ShouldTransformDifferentSpecsAndJoinThemWithSpace()
        {
            // Act
            var actualClassNames = ClassNames.From(
                null,
                "class-name",
                500,
                DirValues.Ltr,
                ("class-name2", true),
                ("class-name3", false),
                (new { shouldAppear1 = true, shouldNotAppear = false }, PropertyAsClassBehavior.AsIs),
                (new { shouldAppear2 = true, shouldNotAppear = false }, PropertyAsClassBehavior.TransformToDashCase),
                new { shouldAppear3 = true, shouldNotAppear = false }.AsIs(),
                new { shouldAppear4 = true, shouldNotAppear = false }.TransformToDashCase(),
                new { shouldAppear5 = true, shouldNotAppear = false }
            );

            // Assert
            Assert.Equal("class-name 500 Ltr class-name2 shouldAppear1 should-appear2 shouldAppear3 should-appear4 should-appear5", actualClassNames);
        }
    }
}
