using NUnit.Framework;

namespace csharptplmaxparallel;


[TestFixture]
class SolutionTests
{
    [Test]
    public void TestCalculate()
    {
        // Arrange
        var solution = new Solution();
        // Act
        int total = solution.Calculate(a, b);
        // Assert
        Assert.AreEqual(expected, total);
    }
}

