using FluentAssertions;
using NUnit.Framework;
using System;

namespace numbergcd;


[TestFixture]
public static class CycleTests
{
    private static void dotest(int n, int expected)
    {
        Console.WriteLine("n: {0}, expected: {1}", n, expected);
        Assert.AreEqual(expected, Cycle.Running(n));
    }

    [Test]
    public static void fixedtest()
    {
        Console.WriteLine("Fixed Tests");
        dotest(3, 1);
        dotest(33, 2);
        dotest(18118, -1);
        dotest(65, -1);
        dotest(197, 98);
    }

    [Test]
    public static void Test69()
    {
        dotest(69, 22);
    }

    [Test]
    public static void Test133771()
    {
        dotest(133771, 6080);
    }

    [Test]
    public static void bigTest()
    {
        dotest(124981, 124980);
    }

    [Test]
    public static void GetRemainByEilerTheorem()
    {
        var result = Cycle.GetModDivInNumberPowDegreeByEiler(7, 222, 10);

        result.Should().Be(9);
        //dotest(133771, 6080);
    }
}
