using NUnit.Framework;

namespace maxsubsetsq;

[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase(new int[] { 5, 4, 1, 2, 2 }, 3)]
    [TestCase(new int[] { 1, 3, 2, 4 }, 1)]
    [TestCase(new int[] { 1, 1 }, 1)]
    public void TestMaximumLength(int[] nums, int expected)
    {
        // Arrange
        // Act
        int maxLength = Solution.MaximumLength(nums);
        // Assert
        Assert.AreEqual(expected, maxLength);
    }

    [Test]
    [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 }, 9)]
    public void TestMaximumLengthBadCase(int[] nums, int expected)
    {
        // Arrange
        // Act
        int maxLength = Solution.MaximumLength(nums);
        // Assert
        Assert.AreEqual(expected, maxLength);
    }
}
