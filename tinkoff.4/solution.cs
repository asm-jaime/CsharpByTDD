using System.Collections.Generic;
using System.Linq;

namespace tinkoff4;

class Solution
{
    public static string GetMinimizedBookList(int[] bookList)
    {
        if(bookList == null || bookList.Length < 3)
        {
            return bookList.Select(book => book.ToString()).Aggregate((acc, e) => $"{acc} {e}");
        }

        bookList = bookList.Distinct().OrderBy(book => book).ToArray();

        List<int> booksZip = new() { bookList.First() };
        bool isLoopInRange = false;
        for(int i = 1; i < bookList.Length - 1; ++i)
        {
            if(bookList[i] - 1 == bookList[i - 1] && bookList[i] + 1 == bookList[i + 1])
            {
                isLoopInRange = true;
                continue;
            }

            if(isLoopInRange)
            {
                booksZip.Add(-1);
                isLoopInRange = false;
            }

            booksZip.Add(bookList[i]);
        }
        if(isLoopInRange)
        {
            booksZip.Add(-1);
            isLoopInRange = false;
        }
        booksZip.Add(bookList.Last());

        return booksZip.Select(book => book == -1 ? "..." : book.ToString()).Aggregate((acc, e) => $"{acc} {e}");
    }
}
