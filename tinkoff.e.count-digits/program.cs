using System;

namespace e;

class Program
{
    static void Main(string[] _)
    {
        long a, b;
        string[] input = Console.ReadLine().Split();
        a = long.Parse(input[0]);
        b = long.Parse(input[1]);

        //var solution = new SolutionSlow();
        long result = Solution.CountSameDigitsNumbers(a, b);

        Console.WriteLine(result);
    }
}