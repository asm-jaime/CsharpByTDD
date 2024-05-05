using NUnit.Framework;

namespace e
{

    [TestFixture]
    class SolutionTests
    {
        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 9)]
        [TestCase(9, 9)]
        [TestCase(8, 9)]
        [TestCase(4, 7)]
        [TestCase(10, 100)]
        [TestCase(10, 634)]
        [TestCase(9, 634)]
        [TestCase(800000, 999999)]
        public void TestCalculate(long a, long b)
        {
            // Arrange
            // Act
            long resultFast = Solution.CountSameDigitsNumbers(a, b);
            long resultSlow = SolutionSlow.CountSameDigitsNumbers(a, b);

            // Assert
            Assert.AreEqual(resultFast, resultSlow);
        }
    }
}

