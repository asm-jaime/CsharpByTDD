using System;

namespace c
{

    class Program
    {
        public static void Main(string[] _)
        {
            string[] firstLine = Console.ReadLine().Split();
            int n = int.Parse(firstLine[0]);
            int t = int.Parse(firstLine[1]);

            int[] floors = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int leavingEmployee = int.Parse(Console.ReadLine());

            var solution = new Solution();
            int minStairs = Solution.GetMinStairClimbed(n, t, floors, leavingEmployee);
            Console.WriteLine(minStairs);
        }
    }
}
