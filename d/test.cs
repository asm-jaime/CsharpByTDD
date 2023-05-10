using NUnit.Framework;

namespace d
{
    [TestFixture]
    public class MaxSumDifferenceTests
    {
        [TestCase(5, 2, new[] { 1, 2, 1, 3, 5 }, 16)]
        [TestCase(3, 1, new[] { 99, 5, 85 }, 10)]
        [TestCase(1, 10, new[] { 9999 }, 0)]
        [TestCase(1, 10, new[] { 9 }, 0)]
        [TestCase(1, 1, new[] { 9 }, 0)]
        [TestCase(1, 1, new[] { 5 }, 4)]
        [TestCase(5, 6, new[] { 100, 850, 15, 700, 255 }, 800 + 100 + 200 + 700 + 90 + 90)]
        [TestCase(5, 5, new[] { 0, 0, 0, 0, 0 }, 5*9)]
        [TestCase(1, 2, new[] { 9999 }, 0)]
        [TestCase(1, 2, new[] { 9000 }, 990)]
        [TestCase(2, 2, new[] { 88, 85 }, 20)]
        [TestCase(2, 3, new[] { 88, 85 }, 24)]
        [TestCase(2, 4, new[] { 88, 85 }, 25)]
        [TestCase(2, 5, new[] { 88, 85 }, 25)]
        [TestCase(2, 2, new[] { 9999, 9 }, 0)]
        [TestCase(2, 2, new[] { 88, 4 }, 15)]
        [TestCase(2, 2, new[] { 1000000000, 1000000000 }, 2*8000000000)]
        public void GetMaxSumDifference_ShouldReturnExpectedResult(int n, int k, int[] a, long expected)
        {
            // Arrange
            var solution = new Solution();

            // Act
            var actual = solution.MaximizeSum(n, k, a);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

