using NUnit.Framework;

namespace tinkoff5;


[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase(new[] { "2 3 5", "1 3 2", "2 3 1", "1 4 2", "3 3 3 3 4" }, 2)]
    [TestCase(new[] { "2 2 5", "1 4 2", "1 3 2", "3 5 5 5 5" }, 0)]
    public void TestPackageDelivery(string[] inputData, int expected)
    {
        // Arrange
        // Act
        int result = Solution.DeliverPackage(inputData);
        // Assert
        Assert.AreEqual(expected, result);
    }
}

