using FluentAssertions;
using NUnit.Framework;

namespace csharpLINQ;

public class RangeTests
{
    [Test]
    public void TestLINQGetSums()
    {
        var range = new Range();

        var (sum, strRange) = range.GetSums();

        sum.Should().Be(15);
        strRange.Should().Be("1,2,3");
    }

    [Test]
    public void TestModifyNumericAndGetSums()
    {
        var range = new Range();

        var (sum, strRange) = range.ModifyNumericAndGetSums();

        sum.Should().Be(15);
        strRange.Should().Be("1,2,0");
    }
}

