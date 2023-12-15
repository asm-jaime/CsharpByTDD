using NUnit.Framework;

namespace a
{
    
    [TestFixture]
    public class SolutionTests
    {
        [Test]
        [TestCase(100, 10, 12, 15, 160)]
        [TestCase(100, 10, 12, 1, 100)]
        public void TestCalculateTotalCost(int a, int b, int c, int d, int expectedTotalCost)
        {
            // Arrange
            Solution solution = new Solution();
            // Act
            int totalCost = solution.CalculateTotalCost(a, b, c, d);
            // Assert
            Assert.AreEqual(expectedTotalCost, totalCost);
        }
    }
}

