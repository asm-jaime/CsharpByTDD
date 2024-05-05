using NUnit.Framework;

namespace dplongestcommonsubsequence;


[TestFixture]
class TestLCS
{
    [Test]
    public void FixedTests()
    {
        Assert.AreEqual("", LcsClass.Lcs("", ""));
        Assert.AreEqual("", LcsClass.Lcs("abc", ""));
        Assert.AreEqual("", LcsClass.Lcs("", "abc"));
        Assert.AreEqual("", LcsClass.Lcs("a", "b"));
        Assert.AreEqual("a", LcsClass.Lcs("a", "a"));
        Assert.AreEqual("ac", LcsClass.Lcs("abc", "ac"));
        Assert.AreEqual("abc", LcsClass.Lcs("abcdef", "abc"));
        Assert.AreEqual("acf", LcsClass.Lcs("abcdef", "acf"));
        Assert.AreEqual("nottest", LcsClass.Lcs("anothertest", "notatest"));
        Assert.AreEqual("12356", LcsClass.Lcs("132535365", "123456789"));
        Assert.AreEqual("final", LcsClass.Lcs("nothardlythefinaltest", "zzzfinallyzzz"));
    }

    [Test]
    public void BadTest()
    {
        Assert.AreEqual("acdefghijklmnoq", LcsClass.Lcs("abcdefghijklmnopq", "apcdefghijklmnobq"));
    }

}
