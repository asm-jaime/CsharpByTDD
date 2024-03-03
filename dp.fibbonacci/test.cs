using NUnit.Framework;

namespace dpfibbonacci;


[TestFixture]
public class Tests
{
    [Test]
    public void Test1()
    {
        Assert.AreEqual(10, FibonacciEvenSum.Fibonacci(10));
        Assert.AreEqual(10, FibonacciEvenSum.Fibonacci(33));
        Assert.AreEqual(19544084, FibonacciEvenSum.Fibonacci(25997544));
    }
}
