using NUnit.Framework;

namespace tinkoff2;

[TestFixture]
class TextAnalyzerTests
{
    [Test]
    [TestCase("a#aba", 1, 3)]
    [TestCase("You_know#how_to_solve#this_task", 8, 12)]
    [TestCase("a#b##c#d#", 0, 1)]
    public void TestAnalyzeText(string text, int expectedMin, int expectedMax)
    {
        // Arrange
        // Act
        var (minLength, maxLength) = TextAnalyzer.AnalyzeText(text);
        
        // Assert
        Assert.AreEqual(expectedMin, minLength);
        Assert.AreEqual(expectedMax, maxLength);
    }
}
