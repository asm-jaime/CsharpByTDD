using FluentAssertions;
using NUnit.Framework;

namespace csharpreferencetypevaluetype;

[TestFixture]
class LosingReferenceTests
{
    [Test]
    public void ShouldTryToLoseReferenceLoseReference()
    {
        var losingReference = new LosingReference(10);

        var value = losingReference.TryToLoseReference(15);

        value.Should().Be(15);
    }
}

