using NUnit.Framework;

namespace tinkoffds2;


[TestFixture]
class SolutionTests
{
    [Test]
    [TestCase(1, 1, 2, 2, "NO")]
    public void TestCalculate(int a, int b, int c, int d, string expected)
    {
        // Arrange
        // Act
        string result = Solution.Calculate(a, b, c, d);
        // Assert
        Assert.AreEqual(result, expected);
    }
}

