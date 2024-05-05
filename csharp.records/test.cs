using FluentAssertions;
using NUnit.Framework;

namespace csharprecords;


[TestFixture]
class SolutionTests
{
    [Test]
    public void TestCalculate()
    {
        // Arrange
        var solution = new Solution();
        // Act
        var result = solution.Calculate();
        // Assert
        result.Should().Be(new Point(1, 3));
    }
}

