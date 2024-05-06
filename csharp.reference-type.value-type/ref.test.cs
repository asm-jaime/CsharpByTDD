using FluentAssertions;
using NUnit.Framework;

namespace csharpreferencetypevaluetype;

[TestFixture]
class RefTests
{
    [Test]
    public void ShouldRefreshValueType()
    {
        var nullificator = new ValueNullificator();

        var value1 = 10;
        var value2 = 10;

        nullificator.NullifyValue(value1);
        nullificator.NullifyValue(ref value2); // will not use boxing, it will pass reference on value2 (reference on stack value)

        value1.Should().Be(10);
        value2.Should().Be(0);
    }
}

