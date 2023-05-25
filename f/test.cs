using NUnit.Framework;
using System.Linq;

namespace f
{
    [TestFixture]
    public class SolutionTests
    {
        [Test]
        [TestCase(new int[] { 2, 1, 4, 6 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 1, 2 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 2, 1 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 1 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 2, 2 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 1, 2, 1 }, new int[] { 1, 3 })]
        [TestCase(new int[] { 1, 2, 2 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 2, 1, 1 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 2, 1, 2 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 1, 1, 2 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 1, 1 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 2, 2, 1 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 2, 2, 2 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 2, 1, 2, 1 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 1, 2, 1, 2 }, new int[] { 1, 3 })]
        [TestCase(new int[] { 2, 1, 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 1, 2, 2 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 2, 1 }, new int[] { 3, 4 })]
        [TestCase(new int[] { 2, 2, 1, 2 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 1, 1, 1, 2 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 1, 2, 1, 1 }, new int[] { -1, -1 })]
        [TestCase(new int[] { 2, 1, 2, 2 }, new int[] { -1, -1 })]
        public void TestSwapPositions(int[] heights, int[] expected)
        {
            // Arrange
            Solution solution = new Solution();
            // Act
            int[] result = solution.SwapPositions(heights);
            // Assert
            Assert.IsTrue(result.SequenceEqual(expected));
        }

        [Test]
        public void TestSwap()
        {
            // Arrange
            Solution solution = new Solution();
            int[] heights = new int[] { 2, 1, 4, 6 };
            int i = 0;
            int j = 1;
            int[] expected = new int[] { 1, 2, 4, 6 };

            // Act
            solution.Swap(heights, i, j);

            // Assert
            Assert.AreEqual(expected, heights);
        }
    }

}

