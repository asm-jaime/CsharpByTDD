using System;
using System.Linq;

namespace minstepsstr2str;

public class Solution
{
    public static int MinSteps(string s, string t)
    {
        var countChByChS = s.GroupBy(ch => ch).ToDictionary(g => g.Key, g => g.Count());
        var countChByChT = t.GroupBy(ch => ch).ToDictionary(g => g.Key, g => g.Count());
        return countChByChS
            .Select(chs =>
                {
                    if (countChByChT.TryGetValue(chs.Key, out var cht))
                    {
                        return Math.Max(chs.Value - cht, 0);
                    }
                    return chs.Value;
                })
            .Aggregate((acc, e) => acc + e);


    }
}
