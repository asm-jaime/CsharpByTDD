using FluentAssertions;
using NUnit.Framework;
using System;

namespace numbergcd;


[TestFixture]
public static class CycleTests
{
    private static void Dotest(int n, int expected)
    {
        Console.WriteLine("n: {0}, expected: {1}", n, expected);
        Assert.AreEqual(expected, Cycle.Running(n));
    }

    [Test]
    public static void Fixedtest()
    {
        Console.WriteLine("Fixed Tests");
        Dotest(3, 1);
        Dotest(33, 2);
        Dotest(18118, -1);
        Dotest(65, -1);
        Dotest(197, 98);
    }

    [Test]
    public static void Test69()
    {
        Dotest(69, 22);
    }

    [Test]
    public static void Test133771()
    {
        Dotest(133771, 6080);
    }

    [Test]
    public static void BigTest()
    {
        Dotest(124981, 124980);
    }

    [Test]
    public static void GetRemainByEilerTheorem()
    {
        var result = Cycle.GetModDivInNumberPowDegreeByEiler(7, 222, 10);

        result.Should().Be(9);
        //dotest(133771, 6080);
    }
}
