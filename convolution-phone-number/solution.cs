using System;
using System.Collections.Generic;
using System.Linq;

namespace convolutionphonenumber;

public class Solution
{
    public List<string> GetMinimalPrefixes(long from, long to)
    {
        List<string> result = new List<string>();

        if(from == to)
        {
            result.Add(from.ToString());
            return result;
        }

        if(from > to)
        {
            long temp = from;
            from = to;
            to = temp;
        }

        string fromStr = from.ToString();
        string toStr = to.ToString();

        if (fromStr.Length != toStr.Length)
        {
            return result;
        }

        if(fromStr.Length is 1)
        {
            return GetRangeFromToStr("", long.Parse(fromStr), long.Parse(toStr));
        }

        int lastPrefixIndex = GetLastPrefixIndex(fromStr, toStr);

        result.Add(fromStr);
        for(var index = fromStr.Length - 1; index > lastPrefixIndex; --index)
        {
            result.AddRange(GetRangeFromToStr(fromStr[..index], fromStr[index] - '0' + 1, 9));
        }
        result.AddRange(GetRangeFromToStr(fromStr[..lastPrefixIndex], fromStr[lastPrefixIndex] - '0' + 1, toStr[lastPrefixIndex] - '0' - 1));
        for(var index = lastPrefixIndex + 1; index <= toStr.Length - 1; ++index)
        {
            result.AddRange(GetRangeFromToStr(toStr[..index], 0, toStr[index] - '0' - 1));
        }
        result.Add(toStr);

        return result;
    }

    private static List<string> GetRangeFromToStr(string prefix, long from, long to)
    {
        var result = new List<string>();

        for(var ch = from; ch <= to; ++ch)
        {
            result.Add($"{prefix}{ch}");
        }

        return result;
    }

    private static int GetLastPrefixIndex(string fromStr, string toStr)
    {
        int result = -1;

        for(var index = 0; index < fromStr.Length; ++index)
        {
            if(fromStr[index] == toStr[index])
            {
                continue;
            }
            else
            {
                result = index;
                break;
            }
        }

        return result;
    }
}
