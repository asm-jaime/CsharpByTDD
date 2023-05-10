using NUnit.Framework;
using System;

namespace b
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Solution solution = new Solution();
            int result = solution.GetMinimalCrosses(n);
            Console.WriteLine(result);
        }
    }
}
