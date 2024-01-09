using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public double CalculateHighwayHeight(int[] heights)
    {
        var areas = new List<double>();
        for (int i = 1; i < heights.Length; ++i)
        {
            var area = Math.Max(heights[i - 1], heights[i]) - Math.Abs(heights[i] - heights[i - 1]) / 2.0;
            areas.Add(area);
        }
        return areas.Sum() / areas.Count();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var num = Console.ReadLine();
        string[] input = Console.ReadLine().Split();
        int[] heights = Array.ConvertAll(input, int.Parse);

        Solution solution = new Solution();
        double highwayHeight = solution.CalculateHighwayHeight(heights);

        Console.WriteLine(highwayHeight);
    }
}
