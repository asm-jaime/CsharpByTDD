using FluentAssertions;
using NUnit.Framework;

namespace csharpavoidfinally;


[TestFixture]
public class SolutionTests
{
    [Test]
    public void TestCalculate()
    {
        // Arrange
        Solution solution = new Solution();
        // Act
        var result = solution.Calculate();
        // Assert
        result.Should().Be(false);
    }
}

