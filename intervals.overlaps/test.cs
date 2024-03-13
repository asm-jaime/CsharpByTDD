using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace intervalsoverlaps;


[TestFixture]
public class SolutionTests
{
    [Test]
    public void TestCalculate()
    {
        // Arrange
        var intervals = new int[][] {
            new int[] { 1, 3 },
            new int[] { 4, 6 },
            new int[] { 5, 8 },
            new int[] { 12, 17 },
            new int[] { 20, 23 },
            new int[] { 6, 9 },
            new int[] { 22, 25 },
            new int[] { 13, 15 }
        };

        var expected = new int[][]
        {
            new int[] {1, 9},
            new int[] {12, 17},
            new int[] {20, 25},
        };

        var solution = new Solution();
        // Act
        int[][] result = solution.Calculate(intervals);
        // Assert
        result.Should().Equal(expected, (arr1, arr2) => arr1.SequenceEqual(arr2));
    }
}

