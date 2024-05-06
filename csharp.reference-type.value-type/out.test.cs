using FluentAssertions;
using NUnit.Framework;

namespace csharpreferencetypevaluetype;

[TestFixture]
class OutTests
{
    [Test]
    public void ShouldPassOutValue()
    {
        var outer = new Out();

        var value1 = 10;
        var value2 = 10;

        outer.PassValue(value1);
        outer.PassValue(out value2); // you can pass defined in different place variable

        value1.Should().Be(10);
        value2.Should().Be(15);
    }
}

