using NUnit.Framework;

namespace csharpsqlnonrepeatableread;


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
        int total = solution.Calculate(a, b);
        // Assert
        Assert.AreEqual(expected, total);
    }
}

