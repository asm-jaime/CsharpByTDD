namespace template;

public class Solution {
    public int[][] OnesMinusZeros(int[][] grid) {
        var sumRows = new int[grid.Length];
        var sumCols = new int[grid.First().Length];
        for(var i = 0; i < grid.Length; ++i)
        {
            for(var j = 0; j < grid[i].Length; ++j)
            {
                sumRows[j] += grid[i][j];
                sumCols[i] += grid[i][j];
            }
        }

        var result = new int[grid.Length][];
        for(var i = 0; i < grid.Length; ++i)
        {
            result[i] = new int[grid[i].Length];
            for(var j = 0; j < grid[i].Length; ++j)
            {
                result[i][j] = sumRows[i] - sumCols[j];
            }
        }


        return result;
    }
}