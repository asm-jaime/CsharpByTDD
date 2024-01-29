using NUnit.Framework;

namespace tinkoffds5;


[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase(9, 10, 3)]
    public void TestCalculate(int width, int height, int expected)
    {
        // Arrange
        Solution solution = new Solution();
        // Act
        int result = solution.Calculate(width, height);
        // Assert
        Assert.AreEqual(expected, result);
    }
}

