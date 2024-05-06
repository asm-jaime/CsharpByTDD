using System.Collections.Generic;
using System.Linq;

namespace csharplist;

class EnumerateN
{
    internal int CalculateSumWithInsertDuringEnumeration(int n)
    {
        List<int> numbers = Enumerable.Range(0, n).ToList();

        var result = 0;

        foreach(int number in numbers)
        {
            // You can't insert element when you iterate by Enumerator
            numbers.Insert(2, 10); // InvalidOperationException
            result += number;
        }

        return result;
    }

    internal int CalculateSumWithInsertDuringEnumerationByIndex(int n)
    {
        List<int> numbers = Enumerable.Range(0, n).ToList();

        var result = 0;

        bool isInserted = false;

        for(int i = 0; i < numbers.Count; ++i)
        {
            if (isInserted is false && i > 3)
            {
                numbers.Insert(2, 1); // does not throw any exception
                isInserted = true;
            }
            result += numbers[i];
        }

        return result;
    }
}
