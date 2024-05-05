using FluentAssertions;
using NUnit.Framework;

namespace templatesbehavioralobserver;

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
        result.Should().Be("3");
    }
}

