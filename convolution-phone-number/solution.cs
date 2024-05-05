namespace convolutionphonenumber;

using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public List<string> GetMinimalPrefixes(long from, long to)
    {
        if(from == to) return new List<string> { from.ToString() };
        if(from > to) (from, to) = (to, from);

        var fromStr = from.ToString();
        var toStr = to.ToString();
        if(fromStr.Length != toStr.Length) return new List<string>();

        int GetLastPrefixIndex() => Enumerable.Range(0, fromStr.Length)
                                               .TakeWhile(index => fromStr[index] == toStr[index])
                                               .Count();

        List<string> GetRangeFromToStr(string prefix, int fromDigit, int toDigit) =>
            Enumerable.Range(fromDigit, toDigit - fromDigit + 1)
                      .Select(digit => $"{prefix}{digit}")
                      .ToList();

        int lastPrefixIndex = GetLastPrefixIndex();
        var result = new List<string> { fromStr };
        result.AddRange(
            Enumerable.Range(lastPrefixIndex + 1, fromStr.Length - lastPrefixIndex - 1)
                      .Reverse()
                      .SelectMany(index => GetRangeFromToStr(fromStr[..index], fromStr[index] - '0' + 1, 9))
        );
        if(lastPrefixIndex >= 0)
        {
            result.AddRange(GetRangeFromToStr(fromStr[..lastPrefixIndex], fromStr[lastPrefixIndex] - '0' + 1, toStr[lastPrefixIndex] - '0' - 1));
        }
        result.AddRange(
            Enumerable.Range(lastPrefixIndex + 1, toStr.Length - lastPrefixIndex - 1)
                      .SelectMany(index => GetRangeFromToStr(toStr[..index], 0, toStr[index] - '0' - 1))
        );
        result.Add(toStr);

        return result.Distinct().ToList();
    }
}
