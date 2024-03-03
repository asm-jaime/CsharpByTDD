using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace dayofweek;


[TestFixture]
public class DayOfWeekExtensionMethodsTests
{
    [Test]
    public void Test1()
    {
        // arrange
        var listOfDays = new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday };

        // act
        var actualResult = DayOfWeek.Monday.GetNextClosestDay(listOfDays);

        // assert
        Assert.AreEqual(DayOfWeek.Saturday, actualResult);
    }

    [Test]
    public void Test2()
    {
        // arrange
        var listOfDays = new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Wednesday };

        // act
        var actualResult = DayOfWeek.Sunday.GetNextClosestDay(listOfDays);

        // assert
        Assert.AreEqual(DayOfWeek.Sunday, actualResult);
    }

    [Test]
    public void Test3()
    {
        // arrange
        var listOfDays = new List<DayOfWeek> { DayOfWeek.Thursday, DayOfWeek.Sunday };

        // act
        var actualResult = DayOfWeek.Friday.GetNextClosestDay(listOfDays);

        // assert
        Assert.AreEqual(DayOfWeek.Sunday, actualResult);
    }
}


