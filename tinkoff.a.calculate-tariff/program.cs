using System;

namespace a
{
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

            Solution solution = new Solution();
            int totalCost = solution.CalculateTotalCost(a, b, c, d);

            Console.WriteLine(totalCost);
        }
    }
}