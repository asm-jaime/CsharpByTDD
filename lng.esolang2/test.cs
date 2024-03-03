using NUnit.Framework;

namespace lngesolang2;


[TestFixture, Description("Your interpreter")]
public class EsolangMiddleTest
{
    [Test, Description("should work for some example test cases")]
    public void ExampleTest()
    {
        // Flips the leftmost cell of the tape
        Assert.AreEqual("10101100", Smallfuck.Interpreter("*", "00101100"));
        // Flips the second and third cell of the tape
        Assert.AreEqual("01001100", Smallfuck.Interpreter(">*>*", "00101100"));
        // Flips all the bits in the tape
        Assert.AreEqual("11010011", Smallfuck.Interpreter("*>*>*>*>*>*>*>*", "00101100"));
        // Flips all the bits that are initialized to 0
        Assert.AreEqual("11111111", Smallfuck.Interpreter("*>*>>*>>>*>*", "00101100"));
        // Goes somewhere to the right of the tape and then flips all bits that are initialized to 1, progressing leftwards through the tape
        Assert.AreEqual("00000000", Smallfuck.Interpreter(">>>>>*<*<<*", "00101100"));
    }

    [Test]
    public void BracesTest()
    {
        // Flips the leftmost cell of the tape
        Assert.AreEqual("000", Smallfuck.Interpreter("[[]*>*>*>]", "000"));
        // Flips the second and third cell of the tape
    }

}
