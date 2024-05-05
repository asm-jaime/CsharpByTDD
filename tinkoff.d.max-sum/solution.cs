using System;
using System.Linq;

namespace d;

class Solution
{
    internal static long MaximizeSum(int _, int k, int[] numbers)
    {
        var orderedNumbers = numbers
            .Select(number => number.ToString()).OrderByDescending(e => e.Length).ThenBy(e => e).ToArray();

        int operationIndex = 0;
        int index = -1;
        int prevNumLen = orderedNumbers.First().Length;
        int numLen = orderedNumbers.First().Length;
        long result = 0;

        while (operationIndex < k)
        {
            if (string.Join("", orderedNumbers).Equals("")) break;
            index = (index + 1) % orderedNumbers.Length;

            string strNum = orderedNumbers[index];
            numLen = strNum.Length;
            if (numLen < prevNumLen)
            {
                index = -1;
                prevNumLen = numLen;
                orderedNumbers = orderedNumbers.OrderByDescending((e) => e.Length).ThenBy(e => e).ToArray();
                continue;
            }

            int leftmostDigit = strNum[0] - '0';
            long numberToAdd = (9 - leftmostDigit) * (long)Math.Pow(10, numLen - 1);
            if (numberToAdd > 0)
            {
                operationIndex++;
                result += numberToAdd;
            }
            orderedNumbers[index] = orderedNumbers[index][1..];

        }

        return result;
    }
}
