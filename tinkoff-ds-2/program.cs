using System;

namespace tinkoffds2;

public class Solution
{
    public static string Calculate(int a, int b, int c, int d)
    {
        if (c == 0 && d != 0) return "NO";

        if (c == 0 && d == 0)
        {
            if (a == 0 && b == 0) return "NO";
            return "INF";
        }

        int x = -d / c;
        if (c * x + d == 0 && a * x + b != 0)
        {
            return x.ToString();
        }
        else
        {
            return "NO";
        }
    }
}

class Program
{
    static void Main(string[] _)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());

        string result = Solution.Calculate(a, b, c, d);

        Console.WriteLine(result);
    }
}