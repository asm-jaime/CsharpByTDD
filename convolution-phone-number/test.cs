using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace convolutionphonenumber;


[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase("12", "13", 1)]
    [TestCase("1234", "1235", 3)]
    public void TestLastPrefixIndex(string fromStr, string toStr, int expected)
    {

        // Arrange
        var solution = new Solution();
        // Act
        var result = solution.GetLastPrefixIndex(fromStr, toStr);
        // Assert
        result.Should().Be(expected);
    }

    [Test]
    public void TestRangeFromToStr()
    {

        // Arrange
        var solution = new Solution();
        // Act
        var result = solution.GetRangeFromToStr("", 1, 9);
        // Assert
        result.Aggregate((acc, e) => $"{acc}{e}").Should().Be("123456789");
    }

    [Test]
    public void TestCalculate()
    {
        // Arrange
        var expected = new List<string>
        {
            "9101234567",
            "9101234568",
            "9101234569",
            "910123457",
            "910123458",
            "910123459",
            "91012346",
            "910123470",
            "910123471",
            "910123472",
            "9101234730",
            "9101234731"
        };
        var solution = new Solution();
        // Act
        var result = solution.GetMinimalPrefixes(9101234567, 9101234731);
        // Assert
        result.Should().Equal(expected);
    }

    [Test]
    public void TestCalculate_SequenceFrom10To19()
    {
        // Arrange
        var solution = new Solution();
        var expected = new List<string>
        {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19"
        };

        // Act
        var result = solution.GetMinimalPrefixes(10, 19);

        // Assert
        result.Should().Equal(expected); // Asserting the expected sequence matches the result exactly
    }

    [Test]
    public void TestCalculate_DiscontinuousSequence()
    {
        // Arrange
        var solution = new Solution();
        var expected = new List<string>
        {
            "113",
            "114",
            "115",
            "116",
            "117",
            "118",
            "119",
            "12",
            "13",
            "14",
            "150",
            "151",
            "152"
        };

        // Act
        var result = solution.GetMinimalPrefixes(113, 152);

        // Assert
        result.Should().Equal(expected);
    }
}
