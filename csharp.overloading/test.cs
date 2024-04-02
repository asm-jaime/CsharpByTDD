using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharpoverloading;


[TestFixture]
public class SolutionTests
{
    [Test]
    public void TestOverloading1()
    {
        int i = 8;

        Solution.RefreshValue(i);

        i.Should().Be(8);
    }

    [Test]
    public void TestOverloading2()
    {
        var car = new Car();
        car.Wheels = 4;

        Solution.RefreshValue(car.Wheels);

        car.Wheels.Should().Be(4);
    }

    [Test]
    public void TestOverloading3()
    {
        string model = "Lada Granta";

        Solution.RefreshValue(model);

        model.Should().Be("Lada Granta");
    }

    [Test]
    public void TestOverloading4()
    {
        var lastNames = new List<string>() { "Иванов", "Петров", "Сидоров" };

        Solution.RefreshValue(lastNames);

        string.Join(",", lastNames).Should().Be("Иванов,Петров,Сидоров");
    }
}

