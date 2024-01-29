using NUnit.Framework;

namespace tinkoffds4;


[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase(1, new int[] {1, 3, 4, 10, 11}, 3)]
    public void TestCalculate(int L, int[] particleCoords, int expected)
    {
        // Arrange
        Solution solution = new Solution();
        // Act
        int result = solution.CalculateScans(L, particleCoords);
        // Assert
        Assert.AreEqual(result, expected);
    }
}

