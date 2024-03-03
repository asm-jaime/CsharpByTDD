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
        string display = person.Display();

        display.Should().Be("Employee Sam");
    }
}

