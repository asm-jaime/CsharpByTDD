using NUnit.Framework;

namespace minstepsstr2str;


[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase("bab", "aba", 1)]
    public void TestCalculate(string a, string b, int expected)
    {
        // Arrange
        // Act
        int total = Solution.MinSteps(a, b);
        // Assert
        Assert.AreEqual(expected, total);
    }
}

