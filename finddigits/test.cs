using NUnit.Framework;

namespace finddigits;


[TestFixture]
public class InfiniteDigitalStringTests
{
    [Test]
    public void FixedTests()
    {
        Assert.AreEqual(3, InfiniteDigitalString.findPosition("456"), "...3456...");
        Assert.AreEqual(79, InfiniteDigitalString.findPosition("454"), "...444546...");
        Assert.AreEqual(98, InfiniteDigitalString.findPosition("455"), "...545556...");
        Assert.AreEqual(8, InfiniteDigitalString.findPosition("910"), "...7891011...");
        Assert.AreEqual(188, InfiniteDigitalString.findPosition("9100"), "...9899100...");
        Assert.AreEqual(187, InfiniteDigitalString.findPosition("99100"), "...9899100...");
        Assert.AreEqual(190, InfiniteDigitalString.findPosition("00101"), "...9899100...");
        Assert.AreEqual(190, InfiniteDigitalString.findPosition("001"), "...9899100...");
        Assert.AreEqual(190, InfiniteDigitalString.findPosition("00"), "...9899100...");
        Assert.AreEqual(0, InfiniteDigitalString.findPosition("123456789"));
        Assert.AreEqual(0, InfiniteDigitalString.findPosition("1234567891"));
        Assert.AreEqual(1000000071, InfiniteDigitalString.findPosition("123456798"));
        Assert.AreEqual(9, InfiniteDigitalString.findPosition("10"));
        Assert.AreEqual(13034, InfiniteDigitalString.findPosition("53635"));
        Assert.AreEqual(1091, InfiniteDigitalString.findPosition("040"));
        Assert.AreEqual(11, InfiniteDigitalString.findPosition("11"));
        Assert.AreEqual(168, InfiniteDigitalString.findPosition("99"));
        Assert.AreEqual(122, InfiniteDigitalString.findPosition("667"));
        Assert.AreEqual(15050, InfiniteDigitalString.findPosition("0404"));
        Assert.AreEqual(382689688L, InfiniteDigitalString.findPosition("949225100"));
        Assert.AreEqual(24674951477L, InfiniteDigitalString.findPosition("58257860625"));
        Assert.AreEqual(6957586376885L, InfiniteDigitalString.findPosition("3999589058124"));
        Assert.AreEqual(1686722738828503L, InfiniteDigitalString.findPosition("555899959741198"));
        Assert.AreEqual(10, InfiniteDigitalString.findPosition("01"));
        Assert.AreEqual(170, InfiniteDigitalString.findPosition("091"));
        Assert.AreEqual(2927, InfiniteDigitalString.findPosition("0910"));
        Assert.AreEqual(2617, InfiniteDigitalString.findPosition("0991"));
        Assert.AreEqual(2617, InfiniteDigitalString.findPosition("09910"));
        Assert.AreEqual(35286, InfiniteDigitalString.findPosition("09991"));
    }
}
