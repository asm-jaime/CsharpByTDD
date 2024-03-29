using FluentAssertions;
using NUnit.Framework;

namespace csharpvirtualoverride;


[TestFixture]
public class VirtualOverrideTests
{
    [Test]
    public void ShouldEmployeReturnOverridedPerson()
    {
        Person person = new Employee { Name = "Sam", Company = "Microsoft" };

        person.Display().Should().Be("Employee Sam");
    }

    [Test]
    public void ShouldMetodBeOverrided()
    {
        Base @base = new Employee { Name = "Base", Company = "Base" };

        @base.OverridedMethod().Should().Be("Overrided 2");
    }

    [Test]
    public void ShouldHideMethod()
    {
        Base @base = new Employee { Name = "Base", Company = "Base" };
        Employee employee = (Employee) @base;

        @base.HideMethod().Should().Be("Hide 1");
        employee.HideMethod().Should().Be("Hide 2");
    }
}

