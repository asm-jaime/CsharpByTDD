using FluentAssertions;
using NUnit.Framework;

namespace csharpTPLlock;


[TestFixture]
class SolutionTests
{
    [Test]
    public void TestCalculate()
    {
        // Arrange
        var solution = new Solution();
        // Act
        int result = solution.StartIncrements();
        // Assert
        result.Should().Be(23);
    }
}

