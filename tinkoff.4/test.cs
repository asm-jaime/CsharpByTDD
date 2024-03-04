using NUnit.Framework;

namespace tinkoff4;


[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase(new int[] { 1, 3, 4, 5, 7, 8, 12 }, "1 3 ... 5 7 8 12")]
    [TestCase(new int[] { 9, 11, 10, 1, 3, 5, 4, 4 }, "1 3 ... 5 9 ... 11")]
    public void TestGetMinimizedBookList(int[] inputList, string expected)
    {
        // Arrange
        // Act
        string minimizedList = Solution.GetMinimizedBookList(inputList);

        // Assert
        Assert.AreEqual(expected, minimizedList);
    }
}

