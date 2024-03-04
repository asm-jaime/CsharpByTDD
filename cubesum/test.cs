using NUnit.Framework;

namespace cubesum;


[TestFixture]
public class CubeSumTests
{

    [Test]
    public void Test1()
    {
        Assert.AreEqual(2022, CubeSum.FindNb(4183059834009));
    }
    [Test]
    public void Test2()
    {
        Assert.AreEqual(-1, CubeSum.FindNb(24723578342962));
    }
    [Test]
    public void Test3()
    {
        Assert.AreEqual(4824, CubeSum.FindNb(135440716410000));
    }
    [Test]
    public void Test4()
    {
        Assert.AreEqual(3568, CubeSum.FindNb(40539911473216));

    }
}

