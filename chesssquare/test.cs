using NUnit.Framework;

namespace chesssquare;


[TestFixture]
public class SolutionTests
{
    /*
    private static Solution _solution;

    [SetUp]
    private static void Initialize()
    {
        _solution = new Solution();
    }
    */

    [Test]
    public void BasicTest()
    {
        Assert.AreEqual(320, Solution.ChessboardSquaresUnderQueenAttack(5, 5));
    }

    [Test]
    public void TestA002378()
    {
        Assert.AreEqual(0, Solution.SUMA002378(1));
        Assert.AreEqual(2, Solution.SUMA002378(2));
        Assert.AreEqual(8, Solution.SUMA002378(3));
    }

    [Test]
    public void TestVH()
    {
        Assert.AreEqual(8, Solution.SquaresVerticalHorizontal(2, 2));
        Assert.AreEqual(18, Solution.SquaresVerticalHorizontal(2, 3));
    }

    [Test]
    public void TestStableCross()
    {
        Assert.AreEqual(1, Solution.StableCrossSize(2, 2));
        Assert.AreEqual(2, Solution.StableCrossSize(3, 2));
        Assert.AreEqual(2, Solution.StableCrossSize(2, 3));
        Assert.AreEqual(1, Solution.StableCrossSize(3, 3));
        Assert.AreEqual(1, Solution.StableCrossSize(5, 5));
        Assert.AreEqual(3, Solution.StableCrossSize(5, 3));
    }
}

