using NUnit.Framework;

namespace numbercollapse;

[TestFixture]
public class RangeCollapseTest
{

    [Test]
    public void BasicTests()
    {
        var solution = new RangeCollapse();

        Assert.AreEqual(8, solution.Descriptions(new int[] { 1, 3, 4, 5, 6, 8 }));

        Assert.AreEqual(4, solution.Descriptions(new int[] { 1, 2, 3 }));

        Assert.AreEqual(1, solution.Descriptions(new int[] { 11, 43, 66, 123 }));

        Assert.AreEqual(64, solution.Descriptions(new int[] { 3, 4, 5, 8, 9, 10, 11, 23, 43, 66, 67 }));
    }
}
