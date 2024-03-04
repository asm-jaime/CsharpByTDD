using System;
using System.Globalization;

namespace tinkoff1;

class Program
{
    static void Main(string[] _)
    {
        double x1, y1, x2, y2, x3, y3;
        string[] input = Console.ReadLine().Split();
        x1 = double.Parse(input[0], CultureInfo.InvariantCulture);
        y1 = double.Parse(input[1], CultureInfo.InvariantCulture);

        input = Console.ReadLine().Split();
        x2 = double.Parse(input[0], CultureInfo.InvariantCulture);
        y2 = double.Parse(input[1], CultureInfo.InvariantCulture);

        input = Console.ReadLine().Split();
        x3 = double.Parse(input[0], CultureInfo.InvariantCulture);
        y3 = double.Parse(input[1], CultureInfo.InvariantCulture);

        int totalScore = Solution.ScoreDarts(x1, y1, x2, y2, x3, y3);

        Console.WriteLine(totalScore);
    }
}
