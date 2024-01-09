using NUnit.Framework;

namespace tinkoff1;


[TestFixture]
public class DartGameTests
{
    [Test]
    [TestCase(0.0, 0.0, 0.1, 0.0, 0.5, 0.5, 8)]
    [TestCase(0.5, 0.5, 2.0, 1.0, 0.05, 0.05, 5)]
    [TestCase(2.0, 2.0, 2.0, 2.0, 2.0, 2.0, 0)] // All outside target
    public void TestScoreDarts(double x1, double y1, double x2, double y2, double x3, double y3, int expected)
    {
        // Arrange
        Solution solution = new Solution();
        // Act
        int totalScore = solution.ScoreDarts(x1, y1, x2, y2, x3, y3);
        // Assert
        Assert.AreEqual(expected, totalScore);
    }
}
