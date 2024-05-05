using FluentAssertions;
using NUnit.Framework;

namespace csharplocalfunction;


[TestFixture]
class SolutionTests
{
    [Test]
    [TestCase(2, 2, 4)]
    [TestCase(0, 0, 0)]
    public void TestCalculate(int a, int b, int expected)
    {
        // Arrange
        var solution = new Solution();
        // Act
        int result = solution.Calculate(a, b);
        // Assert
        result.Should().Be(expected + 1);
    }
}

