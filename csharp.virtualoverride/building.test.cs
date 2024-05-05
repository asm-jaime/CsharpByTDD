using FluentAssertions;
using NUnit.Framework;

namespace csharpvirtualoverride;


class BuildingTests
{
    [Test]
    public void ShouldOverrideBuilding1()
    {
        Building house1 = new SkyScraper();

        house1.GetFloors().Should().Be(30);
    }

    [Test]
    public void ShouldOverrideBuilding2()
    {
        House house2 = new SkyScraper();

        house2.GetFloors().Should().Be(30);
    }

    [Test]
    public void ShouldOverrideBuilding3()
    {
        House house3 = new OrdinaryHouse();

        house3.GetFloors().Should().Be(1);
    }

    [Test]
    public void ShouldOverrideBuilding4()
    {
        // OrdinaryHouse house4 = new House();
        // should be type cast error
    }
}

