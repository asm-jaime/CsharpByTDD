using System;

namespace template;

class Program
{
    static void Main(string[] _)
    {
        int a, b;
        string[] input = Console.ReadLine().Split();
        a = int.Parse(input[0]);
        b = int.Parse(input[1]);

        int total = Solution.Calculate(a, b);

        Console.WriteLine(total);
    }
}