using System;
using System.Collections.Generic;
using System.Linq;

namespace dplongestcommonsubsequence;

/*
  #dynamicprogramming #dp #LCS #LongestCommonSubsequence
*/

class LcsClass
{
    private static string RecoverAnswer(string x, string y, int[][] dpTable)
    {
        var result = new List<string>();
        int i = x.Length, j = y.Length;

        while(i > 0 && j > 0)
        {
            if(x[i - 1] == y[j - 1])
            {
                result.Add($"{x[i - 1]}");
                i--; j--;
            }
            else if(dpTable[j - 1][i] == dpTable[j][i])
            {
                j--;
            }
            else
            {
                i--;
            }
        }

        if(result.Count < 1) return "";

        result.Reverse();
        return result.Aggregate((a, b) => $"{a}{b}");
    }
    internal static string Lcs(string x, string y)
    {
        if(string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y)) return "";

        var result = new List<string>();

        var dpTable = Enumerable.Range(0, y.Length + 1).Select(row => new int[x.Length + 1]).ToArray();

        //var trackDpChange = 0;
        for(var row = 1; row < dpTable.Length; ++row)
        {
            for(var col = 1; col < dpTable[row].Length; ++col)
            {
                if(x[col - 1].Equals(y[row - 1]))
                {
                    dpTable[row][col] = dpTable[row - 1][col - 1] + 1;
                }
                else
                {
                    dpTable[row][col] = Math.Max(dpTable[row - 1][col], dpTable[row][col - 1]);
                }
            }
        }

        return RecoverAnswer(x, y, dpTable);
    }
}
