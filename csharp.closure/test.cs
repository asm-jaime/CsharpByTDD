using FluentAssertions;
using NUnit.Framework;

namespace csharpclosure;


[TestFixture]
class SolutionTests
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

