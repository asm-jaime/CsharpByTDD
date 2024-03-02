using FluentAssertions;
using NUnit.Framework;

namespace csharpclosure;


[TestFixture]
public class SolutionTests
{
    [Test]
    public void TestCalculateClosure()
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        string result = solution.Calculate();

        // Assert
        result.Should().Be("55555");
    }
}

