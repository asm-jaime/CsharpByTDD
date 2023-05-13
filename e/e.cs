using System;

namespace MobileOperator
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

            int totalCost;

            if (d <= b)
            {
                totalCost = a;
            }
            else
            {
                int extraMB = d - b;
                totalCost = a + (extraMB * c);
            }

            Console.WriteLine(totalCost);
        }
    }
}