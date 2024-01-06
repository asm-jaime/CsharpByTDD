using System;

namespace e
{


    class Program
    {
        static void Main(string[] args)
        {
            long a, b;
            string[] input = Console.ReadLine().Split();
            a = long.Parse(input[0]);
            b = long.Parse(input[1]);

            //var solution = new SolutionSlow();
            var solution = new Solution();
            long result = solution.CountSameDigitsNumbers(a, b);

            Console.WriteLine(result);
        }
    }
}