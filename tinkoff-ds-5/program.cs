using System;

namespace tinkoffds5;

public class Solution
{
    public int Calculate(int width, int height)
    {
        int lcm = Math.Abs(width / GreatestCommonDivisor(width, height) * height);

        bool hitsWidth = (lcm / width) % 2 == 1;
        bool hitsHeight = (lcm / height) % 2 == 1;

        if (hitsWidth && hitsHeight) return 4;
        if (hitsWidth && !hitsHeight) return 2;
        if (!hitsWidth && hitsHeight) return 3;
        if (!hitsWidth && !hitsHeight) return 1;

        return 0;
    }

    private int GreatestCommonDivisor(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int width, height;
        string[] input = Console.ReadLine().Split();
        width = int.Parse(input[0]);
        height = int.Parse(input[1]);

        Solution solution = new Solution();
        int result = solution.Calculate(width, height);

        Console.WriteLine(result);
    }
}

