using NUnit.Framework;
using System;

namespace b
{
    class Program
    {
        static void Main(string[] _)
        {
            int n = int.Parse(Console.ReadLine());

            int result = Solution.GetMinimalCrosses(n);
            Console.WriteLine(result);
        }
    }
}
