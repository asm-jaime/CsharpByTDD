using NUnit.Framework;

namespace numbercollapse;

[TestFixture]
public class RangeCollapseTest
{

    [Test]
    public void BasicTests()
    {
        Assert.AreEqual(8, RangeCollapse.Descriptions(new int[] { 1, 3, 4, 5, 6, 8 }));

        Assert.AreEqual(4, RangeCollapse.Descriptions(new int[] { 1, 2, 3 }));

        Assert.AreEqual(1, RangeCollapse.Descriptions(new int[] { 11, 43, 66, 123 }));

        Assert.AreEqual(64, RangeCollapse.Descriptions(new int[] { 3, 4, 5, 8, 9, 10, 11, 23, 43, 66, 67 }));
    }
}
