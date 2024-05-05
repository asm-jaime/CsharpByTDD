using FluentAssertions;
using NUnit.Framework;

namespace csharpinheritance;


[TestFixture]
class InheritanceTest
{
    [Test]
    public void TestBaseToInherited()
    {
        Person tom = new() { Name = "Tom" };
        Employee empl = tom as Employee;
        //Employee empl = (Employee)tom;
        tom.Name = "Bob";

        empl.Should().Be(null);
    }
}
