using NUnit.Framework;

namespace tinkofftariff;


[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase(100, 10, 12, 15, 160)]
    [TestCase(100, 10, 12, 1, 100)]
    public void TestCalculate(int a, int b, int c, int d, int expected)
    {
        // Arrange
        Solution solution = new Solution();
        // Act
        int total = solution.Calculate(a, b, c, d);
        // Assert
        Assert.AreEqual(expected, total);
    }
}

