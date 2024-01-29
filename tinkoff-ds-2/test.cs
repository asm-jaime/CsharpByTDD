using NUnit.Framework;

namespace tinkoffds2;


[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase(1, 1, 2, 2, "NO")]
    public void TestCalculate(int a, int b, int c, int d, string expected)
    {
        // Arrange
        Solution solution = new Solution();
        // Act
        string result = solution.Calculate(a, b, c, d);
        // Assert
        Assert.AreEqual(result, expected);
    }
}

