using FluentAssertions;
using NUnit.Framework;
using System;

namespace csharplist;


[TestFixture]
class EnumerateNTests
{
    [Test]
    [TestCase(10, 65)]
    [TestCase(2, 13)]
    public void ShouldThrowExceptionWhenInsertDuringEnumeration(int n, int expected)
    {
        var enumerateN = new EnumerateN();

        Action act = () => enumerateN.CalculateSumWithInsertDuringEnumeration(n);

        act.Should().Throw<InvalidOperationException>();
    }

    [Test]
    [TestCase(10, 65)]
    [TestCase(2, 13)]
    public void ShouldNotThrowExceptionWhenEnumerateDuringIndexWhile(int n, int expected)
    {
        var enumerateN = new EnumerateN();

        Action act = () => enumerateN.CalculateSumWithInsertDuringEnumerationByIndex(n);

        act.Should().NotThrow();
    }
}

