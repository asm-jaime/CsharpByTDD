using System;

namespace f;

class Program
{
    static void Main(string[] _)
    {
        // Read input
        int n = int.Parse(Console.ReadLine());
        int[] heights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // Call solution method
        var solution = new Solution();
        int[] result = Solution.SwapPositions(heights);

        // Write output
        Console.WriteLine($"{result[0]} {result[1]}");
    }
}