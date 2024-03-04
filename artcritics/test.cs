using NUnit.Framework;

namespace artcritics;

[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase(10, new[] { 10, 0, 1, 0, 3 }, 117)]
    [TestCase(5, new[] { 0, 0, 0, 0, 0 }, 0)]
    [TestCase(1, new[] { 1, 1, 1 }, 5)]
    public void TestCalculateBonus(int n, int[] scores, int expected)
    {
        // Arrange
        // Act
        int total = Solution.CalculateBonus(n, scores);
        // Assert
        Assert.AreEqual(expected, total);
    }
}
