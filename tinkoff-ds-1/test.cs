using NUnit.Framework;

namespace tinkoffds1;


[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase("Everyone of us has all we need", "Everyone", 8)]
    public void TestCalculate(string input, string wordExpected, int lenExpected)
    {
        // Arrange
        Solution solution = new Solution();
        // Act
        var (word, len) = solution.Calculate(input.Split(" "));
        // Assert
        Assert.AreEqual(word, wordExpected);
    }
}

