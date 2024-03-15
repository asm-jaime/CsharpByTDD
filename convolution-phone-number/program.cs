using System;

namespace convolutionphonenumber;


class Program
{
    static void Main(string[] args)
    {
        long from, to;
        string[] input = Console.ReadLine().Split();
        from = int.Parse(input[0]);
        to = int.Parse(input[1]);

        var solution = new Solution();
        var result = solution.GetMinimalPrefixes(from, to);

        Console.WriteLine(result);
    }
}