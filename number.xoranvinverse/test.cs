using NUnit.Framework;

namespace numberxoranvinverse;

[TestFixture]
public class SolutionTest
{
    [Test]
    public void XorInvTest()
    {
        Assert.AreEqual(5, Solution.Xor(6), "mystery(6) ");
        Assert.AreEqual(13, Solution.Xor(9), "mystery(9) ");
        Assert.AreEqual(26, Solution.Xor(19), "mystery(19) ");
        Assert.AreEqual(567, Solution.Xor(986), "mystery(986) ");
    }

    [Test]
    public void XorInvInvTest()
    {
        Assert.AreEqual(9, Solution.XorInv(13), "mysteryInv(13)");
        Assert.AreEqual(19, Solution.XorInv(26), "mysteryInv(26)");
        Assert.AreEqual(6, Solution.XorInv(5), "mysteryInv(5)");
    }
}
