using System;

namespace convolutionphonenumber;


class Program
{
    static void Main(string[] args)
    {
        long from, to;
        string[] input = Console.ReadLine().Split();
        from = long.Parse(input[0]);
        to = long.Parse(input[1]);

        var solution = new Solution();
        var result = solution.GetMinimalPrefixes(from, to);

        foreach(var prefix in result) Console.WriteLine(prefix);
    }
}