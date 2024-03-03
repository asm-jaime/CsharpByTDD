using FluentAssertions;
using NUnit.Framework;

namespace csharpinheritance;


[TestFixture]
public class InheritanceTest
{
    [Test]
    public void TestBaseToInherited()
    {
        Person tom = new Person { Name = "Tom" };
        Employee empl = tom as Employee;
        //Employee empl = (Employee)tom;
        tom.Name = "Bob";

        empl.Should().Be(null);
    }
}
