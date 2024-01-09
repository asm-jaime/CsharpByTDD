using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public string GetMinimizedBookList(int[] bookList)
    {
        if (bookList == null || bookList.Length < 3)
        {
            return bookList.Select(book => book.ToString()).Aggregate((acc, e) => $"{acc} {e}");
        }

        bookList = bookList.Distinct().OrderBy(book => book).ToArray();

        List<int> booksZip = new List<int>() { bookList.First() };
        bool isLoopInRange = false;
        for (int i = 1; i < bookList.Length - 1; ++i)
        {
            if (bookList[i] - 1 == bookList[i - 1] && bookList[i] + 1 == bookList[i + 1])
            {
                isLoopInRange = true;
                continue;
            }

            if (isLoopInRange)
            {
                booksZip.Add(-1);
                isLoopInRange = false;
            }

            booksZip.Add(bookList[i]);
        }
        if (isLoopInRange)
        {
            booksZip.Add(-1);
            isLoopInRange = false;
        }
        booksZip.Add(bookList.Last());

        return booksZip.Select(book => book == -1 ? "..." : book.ToString()).Aggregate((acc, e) => $"{acc} {e}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Read the input
        string number = Console.ReadLine();
        string input = Console.ReadLine();
        int[] bookNumbers = input.Split(' ').Select(int.Parse).ToArray();

        // Process the list to get the minimized book list
        Solution solution = new Solution();
        string minimizedList = solution.GetMinimizedBookList(bookNumbers);

        // Output the result
        Console.WriteLine(minimizedList);
    }
}