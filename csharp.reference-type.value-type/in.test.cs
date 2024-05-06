using FluentAssertions;
using NUnit.Framework;

namespace csharpreferencetypevaluetype;

[TestFixture]
class InTests
{
    [Test]
    public void ShouldPassInValue()
    {
        var inner = new In();

        var value1 = 10;
        var value2 = 10;

        inner.PassValue(value1);
        var result = inner.PassValue(in value2); // will not use boxing

        value1.Should().Be(10);
        result.Should().Be(100);
    }
}

