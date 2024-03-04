using NUnit.Framework;

namespace finddigits;


[TestFixture]
public class InfiniteDigitalStringTests
{
    [Test]
    public void FixedTests()
    {
        Assert.AreEqual(3, InfiniteDigitalString.FindPosition("456"), "...3456...");
        Assert.AreEqual(79, InfiniteDigitalString.FindPosition("454"), "...444546...");
        Assert.AreEqual(98, InfiniteDigitalString.FindPosition("455"), "...545556...");
        Assert.AreEqual(8, InfiniteDigitalString.FindPosition("910"), "...7891011...");
        Assert.AreEqual(188, InfiniteDigitalString.FindPosition("9100"), "...9899100...");
        Assert.AreEqual(187, InfiniteDigitalString.FindPosition("99100"), "...9899100...");
        Assert.AreEqual(190, InfiniteDigitalString.FindPosition("00101"), "...9899100...");
        Assert.AreEqual(190, InfiniteDigitalString.FindPosition("001"), "...9899100...");
        Assert.AreEqual(190, InfiniteDigitalString.FindPosition("00"), "...9899100...");
        Assert.AreEqual(0, InfiniteDigitalString.FindPosition("123456789"));
        Assert.AreEqual(0, InfiniteDigitalString.FindPosition("1234567891"));
        Assert.AreEqual(1000000071, InfiniteDigitalString.FindPosition("123456798"));
        Assert.AreEqual(9, InfiniteDigitalString.FindPosition("10"));
        Assert.AreEqual(13034, InfiniteDigitalString.FindPosition("53635"));
        Assert.AreEqual(1091, InfiniteDigitalString.FindPosition("040"));
        Assert.AreEqual(11, InfiniteDigitalString.FindPosition("11"));
        Assert.AreEqual(168, InfiniteDigitalString.FindPosition("99"));
        Assert.AreEqual(122, InfiniteDigitalString.FindPosition("667"));
        Assert.AreEqual(15050, InfiniteDigitalString.FindPosition("0404"));
        Assert.AreEqual(382689688L, InfiniteDigitalString.FindPosition("949225100"));
        Assert.AreEqual(24674951477L, InfiniteDigitalString.FindPosition("58257860625"));
        Assert.AreEqual(6957586376885L, InfiniteDigitalString.FindPosition("3999589058124"));
        Assert.AreEqual(1686722738828503L, InfiniteDigitalString.FindPosition("555899959741198"));
        Assert.AreEqual(10, InfiniteDigitalString.FindPosition("01"));
        Assert.AreEqual(170, InfiniteDigitalString.FindPosition("091"));
        Assert.AreEqual(2927, InfiniteDigitalString.FindPosition("0910"));
        Assert.AreEqual(2617, InfiniteDigitalString.FindPosition("0991"));
        Assert.AreEqual(2617, InfiniteDigitalString.FindPosition("09910"));
        Assert.AreEqual(35286, InfiniteDigitalString.FindPosition("09991"));
    }
}
