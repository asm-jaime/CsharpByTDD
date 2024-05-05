using NUnit.Framework;
using System.Numerics;

namespace fibbonaccirecursive;


[TestFixture]
class FibonacciMillionthTest
{
    [Test]
    public void TestFib0()
    {
        TestFib(0, 0);
    }

    [Test]
    public void TestFib1()
    {
        TestFib(1, 1);
    }

    [Test]
    public void TestFib2()
    {
        TestFib(1, 2);
    }

    [Test]
    public void TestFib3()
    {
        TestFib(2, 3);
    }

    [Test]
    public void TestFib4()
    {
        TestFib(3, 4);
    }

    [Test]
    public void TestFib5()
    {
        TestFib(5, 5);
    }

    [Test]
    public void TestFib6()
    {
        TestFib(-8, -6);
    }

    [Test]
    public void TestFib7()
    {
        TestFib(34, -9);
    }

    private static void TestFib(long expected, int input)
    {
        BigInteger found = Fibonacci.Fib(input);
        Assert.AreEqual(new BigInteger(expected), found);
    }

}
