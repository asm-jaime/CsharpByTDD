using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace removeduplicate;


[TestFixture]
public class SolutionTests
{
    [Test]
    public void TestCalculate1()
    {
        // Arrange
        var solution = new DistinctByHashSet();
        var array = new int[10] {1, 2, 1, 2, 3, 4, 4, 3, 5, 5};
        // Act
        var result = solution.Calculate(array);
        // Assert
        result.Sum().Should().Be(15);
    }

    [Test]
    public void TestCalculate2()
    {
        // Arrange
        var solution = new DistinctBySort();
        var array = new int[10] {1, 2, 1, 2, 3, 4, 4, 3, 5, 5};
        // Act
        var result = solution.Calculate(array);
        // Assert
        result.Sum().Should().Be(15);
    }
}

