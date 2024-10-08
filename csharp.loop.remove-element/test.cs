using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace csharploopremoveelement;


[TestFixture]
class SolutionTests
{
    [Test]
    public void TestCalculate()
    {
        // Arrange
        var solution = new Solution();
        var list = new List<int>() { 1, 2 };
        // Act
        Action actWrong = () => solution.LoopWrongRemove(list, 1);
        Action actRight = () => solution.LoopRightRemove(list, 1);

        // Assert
        actWrong.Should().Throw<InvalidOperationException>();
        actRight.Should().NotThrow();
    }
}

