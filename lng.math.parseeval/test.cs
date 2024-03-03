using NUnit.Framework;

namespace lngmathparseeval;

[TestFixture]
public class AccountTest
{
    private Evaluate ev = new Evaluate();
    [Test]
    public void Eval_Test1()
    {
        Assert.AreEqual("18", ev.eval("2*3&2"));
    }

    [Test]
    public void Eval_Test2()
    {
        Assert.AreEqual("-240", ev.eval("(-(2 + 3)* (1 + 2)) * 4 & 2"));
    }

    [Test]
    public void Eval_Test3()
    {
        Assert.AreEqual("ERROR", (ev.eval("sqrt(-2)*2") + "     ").Substring(0, 5).ToUpper());
    }

    [Test]
    public void Eval_Test4()
    {
        Assert.AreEqual("ERROR", (ev.eval("2*5/0") + "     ").Substring(0, 5).ToUpper());
    }

    [Test]
    public void Eval_Test5()
    {
        Assert.AreEqual("-3906251", ev.eval("-5&3&2*2-1"));
    }

    [Test]
    public void Eval_Test6()
    {
        Assert.AreEqual("169", ev.eval("abs(-(-1+(2*(4--3)))&2)"));
    }
    [Test]
    public void Eval_Test7()
    {
        Assert.AreEqual("error", ev.eval("sqrt(-5&(-9+1--1+--9))"));

    }
    [Test]
    public void Eval_Test8()
    {
        Assert.AreEqual("24.980004", ev.eval("(-5--2*1e-3)&2"));

    }
    [Test]
    public void Eval_Test9()
    {
        Assert.AreEqual("13", ev.eval("sqrt(13&(1+1--1+-1))"));
    }
    [Test]
    public void Eval_Test10()
    {
        Assert.AreEqual("error", ev.eval("sqrt(-5&(9+1--1+-9))"));
    }
    [Test]
    public void Eval_Test11()
    {
        Assert.AreEqual("-0.268800015352128", ev.eval("abs(1+(2-5)--6)* sin(3 + -6) / 2.1"));
    }
    [Test]
    public void Eval_Test12()
    {
        //Assert.AreEqual("0.24009544961522336", ev.eval("abs(1+(2-5)-10) * sin(3 + 10) / 2.1"));
    }
    [Test]
    public void Eval_Test13()
    {
        Assert.AreEqual("8.2405499303962", ev.eval("abs(1+(2-5)--20)* sin(3 + -20) / 2.1"));
    }

    [Test]
    public void Eval_Test14()
    {
        Assert.AreEqual("error", ev.eval("(((sqrt (1e-1*1e1)+12"));
    }
}
