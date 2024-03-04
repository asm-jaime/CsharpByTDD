using System;

namespace tinkofftariff;

class Program
{
    static void Main(string[] _)
    {
        int a, b, c, d;
        string[] input = Console.ReadLine().Split();
        a = int.Parse(input[0]);
        b = int.Parse(input[1]);
        c = int.Parse(input[2]);
        d = int.Parse(input[3]);

        var result = Solution.Calculate(a, b, c, d);

        Console.WriteLine(result);
    }
}
