using NUnit.Framework;

namespace parentheses;

[TestFixture]
class ValidParenthesesTest
{
    [Test]
    public void SampleTest1()
    {
        Assert.AreEqual(true, Parentheses.ValidParentheses("()"));
    }

    [Test]
    public void SampleTest2()
    {
        Assert.AreEqual(false, Parentheses.ValidParentheses(")(((("));
    }

    [TestCase(")((((", ExpectedResult = false)]
    [TestCase("hi(hi)", ExpectedResult = true)]
    [TestCase("(", ExpectedResult = false)]
    public bool ShouldCheckWithSymbols(string str)
    {
        return Parentheses.ValidParentheses(str);
    }
}
