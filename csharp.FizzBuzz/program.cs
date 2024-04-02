using System;
using System.Threading;

namespace csharpFizzBuzz;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        var num = int.Parse(input[0]);

        var solution = new Solution();
        solution.PrintFizzBuzz(num);
    }
}