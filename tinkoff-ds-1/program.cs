using System;
using System.Linq;

namespace tinkoffds1;

public class Solution
{
    public static (string, int) Calculate(string[] words)
    {
        var max = words.Max(word => word.Length);
        var word = words.Where(word => word.Length == max).First();
        return (word, max);
    }
}

class Program
{
    static void Main(string[] _)
    {
        string[] words = Console.ReadLine().Split();

        var (word, len) = Solution.Calculate(words);

        Console.WriteLine(word);
        Console.WriteLine(len);
    }
}