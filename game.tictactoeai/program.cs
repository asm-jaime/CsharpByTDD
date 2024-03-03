using System;

namespace gametictactoeai;

class Program
{
    static void Main(string[] args)
    {
        int a, b;
        string[] input = Console.ReadLine().Split();
        a = int.Parse(input[0]);
        b = int.Parse(input[1]);

        Solution solution = new Solution();
        int total = solution.Calculate(a, b);

        Console.WriteLine(total);
    }
}