using FluentAssertions;
using NUnit.Framework;

namespace csharpcontravariance;

[TestFixture]
class ContrvarianceTests
{
    [Test]
    public void ShouldTryCovariance()
    {
        var contrvariance = new Contrvariance();

        var act = () => contrvariance.TryContrvariance();

        act.Should().NotThrow();

    }
}

