using FluentAssertions;
using NUnit.Framework;

namespace csharpcovariance;

[TestFixture]
class CovarianceTests
{
    [Test]
    public void ShouldTryCovariance()
    {
        var covariance = new Covariance();

        var result = covariance.TryCovariance();

        (result is Concrete).Should().BeTrue();
    }

    [Test]
    public void ShouldSetToRootedDelegateGetRootMethod()
    {
        var covariance = new Covariance();

        var result = covariance.TrySetToRootedDelegateGetRootMethod();

        (result is Root).Should().BeTrue();
        (result is Concrete).Should().BeFalse();
    }

    [Test]
    public void ShouldSetToConcreteDelegateGetConcreteMethod()
    {
        var covariance = new Covariance();

        var result = covariance.TrySetToConcreteDelegateGetConcreteMethod();

        (result is Concrete).Should().BeTrue();
        (result is Root).Should().BeTrue();
    }
}

