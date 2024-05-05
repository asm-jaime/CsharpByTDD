using System;

namespace d;

class Program
{
    internal static void Main(string[] _)
    {
        // Read input from standard input
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] nums = new int[n];
        input = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(input[i]);
        }

        // Call the function to get the maximum sum difference
        long maxDiff = Solution.MaximizeSum(n, k, nums);

        // Write the result to standard output
        Console.WriteLine(maxDiff);

        // Wait for user input before closing the console window
        Console.ReadLine();
    }
}
