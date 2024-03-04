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
        // Act
        string result = Solution.Calculate();

        // Assert
        result.Should().Be("55555");
    }
}

