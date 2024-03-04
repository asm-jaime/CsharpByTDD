using System;

namespace tinkoff3;

class Program
{
    static void Main(string[] _)
    {
        var num = Console.ReadLine();
        string[] input = Console.ReadLine().Split();
        int[] heights = Array.ConvertAll(input, int.Parse);

        var solution = new Solution();
        double highwayHeight = Solution.CalculateHighwayHeight(heights);

        Console.WriteLine(highwayHeight);
    }
}
