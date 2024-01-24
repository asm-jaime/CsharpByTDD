using System;

namespace tinkofftariff;

class Program
{
    static void Main(string[] args)
    {
        int a, b, c, d;
        string[] input = Console.ReadLine().Split();
        a = int.Parse(input[0]);
        b = int.Parse(input[1]);
        c = int.Parse(input[2]);
        d = int.Parse(input[3]);

        var solution = new Solution();

        var result = solution.Calculate(a, b, c, d);

        Console.WriteLine(result);
    }
}
