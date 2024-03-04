using NUnit.Framework;

namespace bitcount;

[TestFixture]
public class BitCountingTest
{
    [TestCase(0, 0)]
    [TestCase(4, 1)]
    [TestCase(7, 3)]
    [TestCase(9, 2)]
    [TestCase(10, 2)]
    public void CountBits(int input, int expectedCount)
    {
        Assert.AreEqual(expectedCount, Solution.CountBits(input));
    }
}
