using System;
using System.Linq;

namespace subsum
{
    class Program
    {
        static void Main(string[] _)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int target = int.Parse(Console.ReadLine());

            var solution = new Solution();
            bool result = Solution.IsSumPassable(arr, target);

            Console.WriteLine(result);
        }
    }
}