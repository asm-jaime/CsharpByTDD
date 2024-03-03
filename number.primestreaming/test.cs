using NUnit.Framework;
using System.Linq;

namespace numberprimestreaming;


[TestFixture]
public class PrimesTest
{

    [Test]
    public void Test_0_10()
    {
        Test(0, 10, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29);
    }

    [Test]
    public void Test_10_10()
    {
        Test(10, 10, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71);
    }

    [Test]
    public void Test_100_10()
    {
        Test(100, 10, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601);
    }

    [Test]
    public void Test_1000_10()
    {
        Test(1000, 10, 7927, 7933, 7937, 7949, 7951, 7963, 7993, 8009, 8011, 8017);
    }

    private void Test(int skip, int limit, params int[] expect)
    {
        int[] found = Primes.Stream().Skip(skip).Take(limit).ToArray();
        Assert.AreEqual(expect, found);
    }

}
