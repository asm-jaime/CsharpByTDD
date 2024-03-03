using NUnit.Framework;

namespace dpcoinscombinations;


[TestFixture]
public class SolutionTests
{
    static Solution _solution;

    [SetUp]
    public static void Initialize(TestContext testContext)
    {
        _solution = new Solution();
    }

    [Test]
    public static void SimpleCase()
    {
        Assert.That(_solution.CountCombinations(4, new[] { 1, 2 }), Is.EqualTo(3));
    }

    [Test]
    public static void AnotherSimpleCase()
    {
        Assert.That(_solution.CountCombinations(10, new[] { 2, 3, 5 }), Is.EqualTo(4));
    }

    [Test]
    public static void NoChange()
    {
        Assert.That(_solution.CountCombinations(11, new[] { 5, 7 }), Is.EqualTo(0));
    }
}

