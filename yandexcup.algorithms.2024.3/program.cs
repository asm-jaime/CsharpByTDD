using System;

namespace yandexcupalgorithms20243;

class Solution
{
    internal int Calculate(string dance)
    {
        int cum_sum = 0;
        int max_position = 0;
        int min_position = 0;

        foreach (char ch in dance)
        {
            if (ch == 'R' || ch == '?')
            {
                cum_sum += 1;
            }
            else if (ch == 'L')
            {
                cum_sum -= 1;
            }

            if (cum_sum > max_position)
                max_position = cum_sum;

            if (cum_sum < min_position)
                min_position = cum_sum;
        }

        return max_position - min_position;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string dance = Console.ReadLine();

        var solution = new Solution();
        int result = solution.Calculate(dance);

        Console.WriteLine(result);
    }
}

