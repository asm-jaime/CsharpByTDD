using System;
using System.Linq;

namespace tinkoff4;

class Program
{
    static void Main(string[] _)
    {
        // Read the input
        string number = Console.ReadLine();
        string input = Console.ReadLine();
        int[] bookNumbers = input.Split(' ').Select(int.Parse).ToArray();

        // Process the list to get the minimized book list
        var solution = new Solution();
        string minimizedList = Solution.GetMinimizedBookList(bookNumbers);

        // Output the result
        Console.WriteLine(minimizedList);
    }
}