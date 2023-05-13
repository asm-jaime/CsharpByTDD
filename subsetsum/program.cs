using System;
using System.Linq;

namespace subsum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int target = int.Parse(Console.ReadLine());

            Solution solution = new Solution();
            bool result = solution.IsSumPassable(arr, target);

            Console.WriteLine(result);
        }
    }
}