using NUnit.Framework;
using System.Linq;

namespace numbereratosfen;


[TestFixture]
public class NumberTheoryTests
{
    [Test]
    public void SampleTestDivisors()
    {
        Assert.That(Divisors.GetAllPrimeFactors(1).Sum(), Is.EqualTo(1));
        Assert.That(Divisors.GetAllPrimeFactors(2).Sum(), Is.EqualTo(2));
        Assert.That(Divisors.GetAllPrimeFactors(3).Sum(), Is.EqualTo(3));
        Assert.That(Divisors.GetAllPrimeFactors(4).Sum(), Is.EqualTo(4));
        Assert.That(Divisors.GetAllPrimeFactors(8).Sum(), Is.EqualTo(6));
        Assert.That(Divisors.GetAllPrimeFactors(9).Sum(), Is.EqualTo(6));
        Assert.That(Divisors.GetAllPrimeFactors(10).Sum(), Is.EqualTo(7));
        Assert.That(Divisors.GetAllPrimeFactors(55).Sum(), Is.EqualTo(16));
        Assert.That(Divisors.GetAllPrimeFactors(110).Sum(), Is.EqualTo(18));
    }
}
