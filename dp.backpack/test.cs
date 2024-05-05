using NUnit.Framework;

namespace dpbackpack;


[TestFixture]
class DPBackpackTaskTest
{
    [Test]
    public static void ExampleTests()
    {
        Assert.That(DPBackpackTask.PackBagpack(new int[] { 15, 10, 9, 5 }, new int[] { 1, 5, 3, 4 }, 8), Is.EqualTo(29));
        Assert.That(DPBackpackTask.PackBagpack(new int[] { 20, 5, 10, 40, 15, 25 }, new int[] { 1, 2, 3, 8, 7, 4 }, 10), Is.EqualTo(60));
    }
}

