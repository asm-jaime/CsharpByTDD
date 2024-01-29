using NUnit.Framework;

namespace tinkoffds3;


[TestFixture]
public class SolutionTests
{
    [Test]
    [TestCase(2, 2, 4)]
    [TestCase(0, 0, 0)]
    public void TestCalculate(int a, int b, int expected)
    {
        // Arrange
        Solution solution = new Solution();
        // Act
        // Assert
    }
}

