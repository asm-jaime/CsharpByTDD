using System;
using System.Collections.Generic;

namespace yandexcupalgorithms20245
{
    class Solution
    {
        internal int CountCombinations(int mass, int[] arr)
        {
            int n = arr.Length;
            List<int> A = new List<int>();
            for(int i = 0; i <= n; i++)
            {
                A.Add((int)Math.Pow(2, i));
            }

            // Use a dictionary for memoization to store intermediate results
            var memo = new Dictionary<(int, int), int>();

            // Recursive helper function
            int Helper(int currentMass, int index)
            {
                // Base cases
                if(currentMass == 0)
                    return 1;
                if(currentMass < 0 || index >= A.Count)
                    return 0;

                // Check if the result is already computed
                var key = (currentMass, index);
                if(memo.ContainsKey(key))
                    return memo[key];

                int total = 0;

                // Iterate through all possible variants in B for the current a_i
                foreach(var b in arr)
                {
                    total += Helper(currentMass - A[index] * b, index + 1);
                }

                // Store the computed result in memo
                memo[key] = total;
                return total;
            }

            // Start recursion from the first element
            return Helper(mass, 0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Read input mass
            int mass = int.Parse(Console.ReadLine());

            // Read the number of elements in B
            int n = int.Parse(Console.ReadLine());

            // Read array B
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            var solution = new Solution();
            var result = solution.CountCombinations(mass, arr);
            Console.WriteLine(result);
        }
    }
}

