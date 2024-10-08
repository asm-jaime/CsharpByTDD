using FluentAssertions;
using NUnit.Framework;

namespace csharpexceptionsequence;


[TestFixture]
class SolutionTests
{
    [Test]
    [TestCase(true,  "throwed, finally, and the end")]
    [TestCase(false, "finally, and the end")]
    public void TestCalculate(bool isThrow, string expected)
    {
        // Arrange
        var solution = new Solution();
        // Act
        var result = solution.GetExceptionSequenceString(isThrow);
        // Assert
        result.Should().Be(expected);
    }
}

