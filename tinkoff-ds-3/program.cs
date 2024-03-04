using System;
using System.Linq;

namespace tinkoffds3;


public class Solution
{
    public static string AreArraysSimilar(int[] array1, int[] array2)
    {
        int[] unique1 = RemoveDuplicates(array1);
        int[] unique2 = RemoveDuplicates(array2);

        if (unique1.Length != unique2.Length)
        {
            return "NO";
        }

        for (int i = 0; i < unique1.Length; i++)
        {
            if (unique1[i] != unique2[i])
            {
                return "NO";
            }
        }

        return "YES";
    }

    private static int[] RemoveDuplicates(int[] array)
    {
        int[] result = new int[array.Length];
        int resultIndex = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (i == 0 || array[i] != array[i - 1])
            {
                result[resultIndex++] = array[i];
            }
        }
        return result.Take(resultIndex).ToArray();
    }
}

class Program
{
    static void Main(string[] _)
    {
        int[] array1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] array2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        var solution = new Solution();
        string result = Solution.AreArraysSimilar(array1, array2);

        Console.WriteLine(result);
    }
}
