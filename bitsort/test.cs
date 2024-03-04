using FluentAssertions;
using NUnit.Framework;

namespace bitsort;


[TestFixture]
public class SolutionTests
{
    [Test]
    public void ShouldMakeSortedNumber()
    {
        Solution.SortBits("000000100000011101010101000000101101000100000001").Should().Be("122785209");
    }
}

