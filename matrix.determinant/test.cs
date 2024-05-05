using NUnit.Framework;
using FluentAssertions;

namespace matrixdeterminant;


[TestFixture]
class MatrixTest
{

    private static readonly int[][][] matrix =
    {
            new int[][] { new [] { 1 } },
            new int[][] { new [] { 1, 3 }, new [] { 2, 5 } },
            new int[][] {
                new [] { 2, 5, 3 },
                new [] { 1,-2,-1 },
                new [] { 1, 3, 4 }
            },
            new int[][] {
                new [] { 1, 2, 3, 5 },
                new [] { 0, 5, -10, 1 },
                new [] { 8,-4, 6, 6 },
                new [] { 8, 8, 9, 7 }
            }
        };

    private static readonly int[] expected = { 1, -1, -20, 4456 };

    private static readonly string[] msg = { "Determinant of a 1 x 1 matrix yields the value of the one element", "Should return 1 * 5 - 3 * 2 == -1 ", "", "" };

    public static void SampleTests()
    {
        for(int n = 0; n < expected.Length; n++)
            Assert.AreEqual(expected[n], Matrix.Determinant(matrix[n]), msg[n]);
    }

    [TestCase(2, ExpectedResult = -20)]
    [TestCase(3, ExpectedResult = 4456)]
    public int TestHighRankMatrix(int matrixIndex)
    {
        return Matrix.Determinant(matrix[matrixIndex]);
    }


    [Test]
    public void ShouldGetSubmatrix()
    {
        var matrix = new int[][] {
                new [] {1, 2, 3},
                new [] {4, 5, 6},
                new [] {7, 8, 9},
            };
        var subMatrix = new int[][] {
                new [] {5, 6},
                new [] {8, 9},
            };

        var newMatrix = IDeterminant.GetMinorElement(matrix, 0, 0);

        newMatrix.Should().BeEquivalentTo(subMatrix);
        //newMatrix.Should().Contain(subMatrix[0]);
        //newMatrix.Should().Contain(subMatrix[1]);
    }
}
