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
        // Act
        var result = Solution.Calculate();
        // Assert
        result.Should().Be(false);
    }
}

