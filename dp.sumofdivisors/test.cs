using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace dpsumofdivisors;

[TestFixture]
public static class ThirdPowTests
{

    //[Test]
    public static void test1()
    {
        Assert.AreEqual(6, ThirdPow.IntCubeSumDiv(1));
        Assert.AreEqual(28, ThirdPow.IntCubeSumDiv(2));
        Assert.AreEqual(30, ThirdPow.IntCubeSumDiv(3));
        Assert.AreEqual(84, ThirdPow.IntCubeSumDiv(4));
        Assert.AreEqual(102, ThirdPow.IntCubeSumDiv(5));
        Assert.AreEqual(71880, ThirdPow.IntCubeSumDiv(100));
    }

    [Test]
    public static void test3()
    {

        Assert.AreEqual(6, ThirdPow.IntCubeSumDiv(1));
        Assert.AreEqual(102, ThirdPow.IntCubeSumDiv(5));
        //Assert.AreEqual(28, ThirdPow.IntCubeSumDiv(2));
        Assert.AreEqual(71880, ThirdPow.IntCubeSumDiv(110));
        //Assert.AreEqual(28, ThirdPow.IntCubeSumDiv(2));
        //Assert.AreEqual(81840, ThirdPow.IntCubeSumDiv(150));
    }

    //[Test]
    public static void test2()
    {
        var original = new List<long>() { 1, 2, 3, 6 };
        var divisors = ThirdPow.GetAllDivisors(6);
        //divisors.Sort();
        //original.SequenceEqual(divisors).Should().Be(true);
    }
    //[Test]
    public static void testEratosfen()
    {
        ThirdPow.GetPrimesByEratosfen(100000).Count().Should().Be(4);
    }
    //[Test]
    public static void testPrimeDivisors()
    {
        //ThirdPow.GetAllPrimeDivisors(8)[2].Should().Be(3);
        //ThirdPow.GetAllPrimeDivisors(0).Count().Should().Be(0);
        (ThirdPow.GetSumOfPrimeFactors(ThirdPow.GetAllPrimeFactors(6))).Should().Be(12);
    }
}
