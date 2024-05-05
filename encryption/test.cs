using NUnit.Framework;

namespace encryption;


[TestFixture]
class SolutionTest
{
    [Test]
    public void EncryptExampleTests()
    {
        Assert.AreEqual("This is a test!", Encryption.Encrypt("This is a test!", 0));
        Assert.AreEqual("hsi  etTi sats!", Encryption.Encrypt("This is a test!", 1));
        Assert.AreEqual("s eT ashi tist!", Encryption.Encrypt("This is a test!", 2));
        Assert.AreEqual(" Tah itse sits!", Encryption.Encrypt("This is a test!", 3));
        Assert.AreEqual("This is a test!", Encryption.Encrypt("This is a test!", 4));
        Assert.AreEqual("This is a test!", Encryption.Encrypt("This is a test!", -1));
        Assert.AreEqual("hskt svr neetn!Ti aai eyitrsig", Encryption.Encrypt("This kata is very interesting!", 1));
    }

    [Test]
    public void DecryptExampleTests()
    {
        Assert.AreEqual("This is a test!", Encryption.Decrypt("This is a test!", 0));
        Assert.AreEqual("This is a test!", Encryption.Decrypt("hsi  etTi sats!", 1));
        Assert.AreEqual("This is a test!", Encryption.Decrypt("s eT ashi tist!", 2));
        Assert.AreEqual("This is a test!", Encryption.Decrypt(" Tah itse sits!", 3));
        Assert.AreEqual("This is a test!", Encryption.Decrypt("This is a test!", 4));
        Assert.AreEqual("This is a test!", Encryption.Decrypt("This is a test!", -1));
        Assert.AreEqual("This kata is very interesting!", Encryption.Decrypt("hskt svr neetn!Ti aai eyitrsig", 1));
    }

    [Test]
    public void EmptyTests()
    {
        Assert.AreEqual("", Encryption.Encrypt("", 0));
        Assert.AreEqual("", Encryption.Decrypt("", 0));
    }

    [Test]
    public void NullTests()
    {
        Assert.AreEqual(null, Encryption.Encrypt(null, 0));
        Assert.AreEqual(null, Encryption.Decrypt(null, 0));
    }
}

