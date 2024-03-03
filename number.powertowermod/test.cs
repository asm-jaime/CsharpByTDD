using NUnit.Framework;
using System.Numerics;

namespace numberpowertowermod;

[TestFixture]
public class BasicTests
{
    [TestCase(729, 0, 1, 0)]
    [TestCase(729, 0, 2, 1)]
    [TestCase(1, 897, 8934279, 1)]
    public void CornerCases(int b, int h, int m, int expected)
        => Tester.Act(b, h, m, expected);

    [TestCase(2, 2, 1000, 4)]
    [TestCase(2, 3, 100000, 16)]
    [TestCase(2, 4, 100000000, 65536)]
    [TestCase(4, 2, 10000000, 256)]
    [TestCase(4, 3, 10, 6)]
    [TestCase(7, 1, 5, 2)]
    [TestCase(2, 5, 65519, 68)]
    public void SmallValues(int b, int h, int m, int expected)
        => Tester.Act(b, h, m, expected);

    [Test(Description = "Cannot replace base with base % m")]
    public void CannotReplaceBaseWithBaseModuloM()
    {
        Assert.AreNotEqual(
            PowerTowerMod.Tower(28, 3, 25),
            PowerTowerMod.Tower(28 % 25, 3, 25),
            "Cannot replace base with base % m");
    }

    [Test(Description = "Cannot replace the exponent with exponent % m")]
    public void CannotReplaceExpWithExpModuloM()
    {
        Assert.AreNotEqual(
            (BigInteger)PowerTowerMod.Tower(13, 3, 31),
            BigInteger.ModPow(13, PowerTowerMod.Tower(13, 2, 31), 31),
            "Cannot replace the exponent with exponent % m");
    }

    [Test(Description = "However, there are cycles in the exponent...")]
    public void HoweverThereAreCyclesInExp()
    {
        Assert.AreEqual(
            (BigInteger)PowerTowerMod.Tower(13, 3, 31),
            BigInteger.ModPow(13, PowerTowerMod.Tower(13, 2, 30), 31),
            "However, there are cycles in the exponent...");

        Assert.AreEqual(
            (BigInteger)PowerTowerMod.Tower(13, 3, 31),
            BigInteger.ModPow(13, 30 + PowerTowerMod.Tower(13, 2, 30), 31),
            "However, there are cycles in the exponent...");
    }

    [Test(Description = @"Pushing the limit of ""small""")]
    public void PushingTheLimitOfSmall()
    {
        var t_3_3 = BigInteger.Pow(3, 27);
        var t_3_4 = BigInteger.ModPow(3, t_3_3, 1001);
        Assert.AreEqual(
            (BigInteger)PowerTowerMod.Tower(3, 4, 1001),
            t_3_4,
            @"Pushing the limit of ""small""");
    }

    [Test(Description = "Replace exponent with..?!")]
    public void ReplaceExponentWith()
    {
        var t_2_4 = BigInteger.Pow(2, 16);
        var t_2_5 = BigInteger.ModPow(2, t_2_4, 720);
        var t_2_6 = BigInteger.ModPow(2, 720 + t_2_5, 1001);
        Assert.AreEqual(
            (BigInteger)PowerTowerMod.Tower(2, 6, 1001),
            t_2_6,
            "Replace exponent with..?!");
    }

    [TestCase(2, 4, 131072, 65536)]
    public void SpecialCase(int b, int h, int m, int expected)
        => Tester.Act(b, h, m, expected);
}

static class Tester
{
    internal static void Act(BigInteger b, BigInteger h, int m, int expected)
    {
        var msg = $"Invalid answer for base: {b} height: {h} modulus: {m}";
        var actual = PowerTowerMod.Tower(b, h, m);
        Assert.AreEqual(expected, actual, msg);
    }
}
