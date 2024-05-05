using NUnit.Framework;

namespace a
{
    
    [TestFixture]
    class SolutionTests
    {
        [Test]
        [TestCase(100, 10, 12, 15, 160)]
        [TestCase(100, 10, 12, 1, 100)]
        public void TestCalculateTotalCost(int a, int b, int c, int d, int expectedTotalCost)
        {
            // Arrange
            // Act
            int totalCost = Solution.CalculateTotalCost(a, b, c, d);
            // Assert
            Assert.AreEqual(expectedTotalCost, totalCost);
        }
    }
}

