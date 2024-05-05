using System.Linq;

namespace diffmatrix;

class Solution
{
    public static int[][] OnesMinusZeros(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var sumRows = new int[rows];
        var sumCols = new int[cols];

        for (var i = 0; i < rows; ++i)
        {
            for (var j = 0; j < cols; ++j)
            {
                sumRows[i] += grid[i][j] == 1 ? 1 : -1;
                sumCols[j] += grid[i][j] == 1 ? 1 : -1;
            }
        }

        var result = new int[rows][];
        for (var i = 0; i < rows; ++i)
        {
            result[i] = new int[cols];
            for (var j = 0; j < cols; ++j)
            {
                result[i][j] = sumRows[i] + sumCols[j];
            }
        }


        return result;
    }
}