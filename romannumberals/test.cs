using NUnit.Framework;

namespace romannumberals;

[TestFixture]
public class RomanNumeralsTests
{
    [Test]
    public void TestToRoman_001()
    {
        int input = 1;
        string expected = "I";

        string actual = RomanNumerals.ToRoman(input);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestToRoman_002()
    {
        int input = 2;
        string expected = "II";

        string actual = RomanNumerals.ToRoman(input);

        Assert.AreEqual(expected, actual);
    }

    [TestCase(1666, ExpectedResult = "MDCLXVI")]
    [TestCase(2008, ExpectedResult = "MMVIII")]
    [TestCase(1000, ExpectedResult = "M")]
    public string TestToRoman_003(int input)
    {
        string result = RomanNumerals.ToRoman(input);
        return result;
    }

    [Test]
    public void TestFromRoman_001()
    {
        string input = "I";
        int expected = 1;

        int actual = RomanNumerals.FromRoman(input);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestFromRoman_002()
    {
        string input = "II";
        int expected = 2;

        int actual = RomanNumerals.FromRoman(input);

        Assert.AreEqual(expected, actual);
    }

    [TestCase("MDCLXVI", ExpectedResult = 1666)]
    [TestCase("MMVIII", ExpectedResult = 2008)]
    [TestCase("M", ExpectedResult = 1000)]
    [TestCase("IV", ExpectedResult = 4)]
    [TestCase("XLIV", ExpectedResult = 44)]
    public int TestFromRoman_003(string input)
    {
        var result = RomanNumerals.FromRoman(input);
        return result;
    }

    [Test]
    public void TestWrongNumber()
    {
        string input = "IVI";
        int expected = -1;

        int actual = RomanNumerals.FromRoman(input);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
