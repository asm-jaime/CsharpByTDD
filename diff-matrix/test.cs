using FluentAssertions;
using NUnit.Framework;

namespace diffmatrix;


[TestFixture]
public class SolutionTests
{
    [Test]
    public void Test1()
    {
        // Arrange
        var binaryArray = new int[3][] { new int[] { 0, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 0, 0, 1 } };

        // Act
        int[][] total = Solution.OnesMinusZeros(binaryArray);
        // Assert
        var expected = new int[3][] { new int[] { 0, 0, 4 }, new int[] { 0, 0, 4 }, new int[] { -2, -2, 2 } };
        total.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void Test2()
    {
        // Arrange
        var binaryArray = new int[2][] { new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 } };

        // Act
        int[][] total = Solution.OnesMinusZeros(binaryArray);

        // Assert
        var expected = new int[2][] { new int[] { 5, 5, 5 }, new int[] { 5, 5, 5 } };
        total.Should().BeEquivalentTo(expected);
    }

}

