namespace artcritics;

using System;
using System.Linq;

class Program
{
    public static void Main()
    {
        // Reading input
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = nm[0];
        int m = nm[1]; // m is the number of criteria, which can also be derived from the length of the scores array

        var scores = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var solution = new Solution();
        // Calculating bonus score
        int totalBonus = Solution.CalculateBonus(n, scores);

        // Printing result
        Console.WriteLine(totalBonus);
    }

}
