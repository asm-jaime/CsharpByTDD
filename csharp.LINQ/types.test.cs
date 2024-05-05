using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace csharpLINQ;

class SolutionTests
{
    [Test]
    public void TestCalculate()
    {
        // Arrange
        var objects = new object[] { "One", "Two", "Three", "Four", "Five", 6 };
        // Act
        var result = Types.GetOrderedStrings(objects);
        // Assert
        result.SequenceEqual(new List<string>() { "One", "Two", "Five", "Four", "Three" }).Should().BeTrue();
    }
}

