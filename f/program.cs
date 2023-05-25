using System;

namespace f;

class Program
{
    static void Main(string[] args)
    {
        // Read input
        int n = int.Parse(Console.ReadLine());
        int[] heights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // Call solution method
        Solution solution = new Solution();
        int[] result = solution.SwapPositions(heights);

        // Write output
        Console.WriteLine($"{result[0]} {result[1]}");
    }
}