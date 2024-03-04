using NUnit.Framework;

namespace b
{
    [TestFixture]
    public class SolutionTests
    {
        [Test]
        [TestCase(6, 3)]
        [TestCase(5, 3)]
        public void TestGetMinimalCrosses(int pieces, int expectedCrosses)
        {
            // Arrange
            // Act
            int actualCrosses = Solution.GetMinimalCrosses(pieces);
            // Assert
            Assert.AreEqual(expectedCrosses, actualCrosses);
        }
    }
}

