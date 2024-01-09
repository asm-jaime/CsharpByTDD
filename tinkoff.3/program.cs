using System;

namespace tinkoff3;

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
