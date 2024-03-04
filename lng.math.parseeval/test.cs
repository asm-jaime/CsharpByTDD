using NUnit.Framework;

namespace lngmathparseeval;

[TestFixture]
public class AccountTest
{
    private readonly Evaluate ev = new();
    [Test]
    public void Eval_Test1()
    {
        Assert.AreEqual("18", ev.Eval("2*3&2"));
    }

    [Test]
    public void Eval_Test2()
    {
        Assert.AreEqual("-240", ev.Eval("(-(2 + 3)* (1 + 2)) * 4 & 2"));
    }

    [Test]
    public void Eval_Test3()
    {
        Assert.AreEqual("ERROR", (ev.Eval("sqrt(-2)*2") + "     ")[..5].ToUpper());
    }

    [Test]
    public void Eval_Test4()
    {
        Assert.AreEqual("ERROR", (ev.Eval("2*5/0") + "     ")[..5].ToUpper());
    }

    [Test]
    public void Eval_Test5()
    {
        Assert.AreEqual("-3906251", ev.Eval("-5&3&2*2-1"));
    }

    [Test]
    public void Eval_Test6()
    {
        Assert.AreEqual("169", ev.Eval("abs(-(-1+(2*(4--3)))&2)"));
    }
    [Test]
    public void Eval_Test7()
    {
        Assert.AreEqual("error", ev.Eval("sqrt(-5&(-9+1--1+--9))"));

    }
    [Test]
    public void Eval_Test8()
    {
        Assert.AreEqual("24.980004", ev.Eval("(-5--2*1e-3)&2"));

    }
    [Test]
    public void Eval_Test9()
    {
        Assert.AreEqual("13", ev.Eval("sqrt(13&(1+1--1+-1))"));
    }
    [Test]
    public void Eval_Test10()
    {
        Assert.AreEqual("error", ev.Eval("sqrt(-5&(9+1--1+-9))"));
    }
    [Test]
    public void Eval_Test11()
    {
        Assert.AreEqual("-0.268800015352128", ev.Eval("abs(1+(2-5)--6)* sin(3 + -6) / 2.1"));
    }
    [Test]
    public void Eval_Test12()
    {
        //Assert.AreEqual("0.24009544961522336", ev.eval("abs(1+(2-5)-10) * sin(3 + 10) / 2.1"));
    }
    [Test]
    public void Eval_Test13()
    {
        Assert.AreEqual("8.2405499303962", ev.Eval("abs(1+(2-5)--20)* sin(3 + -20) / 2.1"));
    }

    [Test]
    public void Eval_Test14()
    {
        Assert.AreEqual("error", ev.Eval("(((sqrt (1e-1*1e1)+12"));
    }
}
