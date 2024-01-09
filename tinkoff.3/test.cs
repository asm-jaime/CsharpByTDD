using NUnit.Framework;

namespace tinkoff3;

[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase(new int[] { 1, 2, 3 }, 2.0)]
    [TestCase(new int[] { 1, 1, 1, 1 }, 1.0)]
    [TestCase(new int[] { 0, 1, 1, 0 }, 0.6667)]
    public void TestCalculateHighwayHeight(int[] heights, double expected, double delta = 0.0001)
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        double result = solution.CalculateHighwayHeight(heights);

        // Assert
        Assert.AreEqual(expected, result, delta);
    }
}
