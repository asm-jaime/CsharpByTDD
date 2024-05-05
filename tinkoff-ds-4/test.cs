using NUnit.Framework;

namespace tinkoffds4;


[TestFixture]
class SolutionTests
{
    [Test]
    [TestCase(1, new int[] {1, 3, 4, 10, 11}, 3)]
    public void TestCalculate(int L, int[] particleCoords, int expected)
    {
        // Arrange
        // Act
        int result = Solution.CalculateScans(L, particleCoords);
        // Assert
        Assert.AreEqual(result, expected);
    }
}

