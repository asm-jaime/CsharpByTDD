using NUnit.Framework;

namespace yandexcupbackend20241;


[TestFixture]
class SolutionTests
{
    [Test]
    [TestCase(2, 2, 4)]
    [TestCase(0, 0, 0)]
    public void TestCalculate(int a, int b, int expected)
    {
        // Arrange
    }
}

