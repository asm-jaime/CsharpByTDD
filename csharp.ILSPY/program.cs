using System;

namespace csharpILSPY;

class Program
{
    static void Main(string[] args)
    {
        int a, b;
        string[] input = Console.ReadLine().Split();
        a = int.Parse(input[0]);
        b = int.Parse(input[1]);

        var solution = new Solution();
        int total = solution.Calculate(a, b);

        Console.WriteLine(total);
    }
}