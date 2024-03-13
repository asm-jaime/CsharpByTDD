using System;
using System.Collections.Generic;

namespace intervalsoverlaps;

public class Solution
{
    public int[][] Calculate(int[][] intervals)
    {
        var result = new List<int[]>();

        Array.Sort(intervals, (first, second) => first[0] - second[0]);

        var acc = intervals[0];
        for(var i = 1; i < intervals.Length; ++i)
        {
            if(acc[1] + 1 >= intervals[i][0])
            {
                acc[0] = Math.Min(acc[0], intervals[i][0]);
                acc[1] = Math.Max(acc[1], intervals[i][1]);
            }
            else
            {
                result.Add(acc);
                acc = intervals[i];
            }
        }
        result.Add(acc);

        return result.ToArray();
    }
}
