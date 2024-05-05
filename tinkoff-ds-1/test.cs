using NUnit.Framework;

namespace tinkoffds1;


[TestFixture]
class SolutionTests
{
    [Test]
    [TestCase("Everyone of us has all we need", "Everyone", 8)]
    public void TestCalculate(string input, string wordExpected, int _)
    {
        // Arrange
        // Act
        var (word, _) = Solution.Calculate(input.Split(" "));
        // Assert
        Assert.AreEqual(word, wordExpected);
    }
}

