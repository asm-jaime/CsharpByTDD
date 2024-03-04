using NUnit.Framework;

namespace subsum
{
    [TestFixture]
    public class SolutionTests
    {
        [Test]
        [TestCase(new int[] { 3, 1, 8, 5, 4 }, 10, true)]
        [TestCase(new int[] { 3, 1, 8, 5, 4 }, 2, false)]
        [TestCase(new int[] {1, 5, 3, 7, 4}, 12, true)]
        [TestCase(new int[] {1, 5, 3, 7, 4}, 100, false)]
        public void TestCanSumToTarget(int[] arr, int target, bool expected)
        {
            // Arrange
            // Act
            bool result = Solution.IsSumPassable(arr, target);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}