using NUnit.Framework;

namespace tinkoffds5;


[TestFixture]
class SolutionTests
{
    [Test]
    [TestCase(9, 10, 3)]
    public void TestCalculate(int width, int height, int expected)
    {
        // Arrange
        // Act
        int result = Solution.Calculate(width, height);
        // Assert
        Assert.AreEqual(expected, result);
    }
}

