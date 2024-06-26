﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace bitsort;

class Solution
{
    const int DefaultBase = 2;
    const string SelectEightDigitsPattern = @"\d{8}";

    internal static string SortBits(string bits)
    {
        return Regex
            .Matches(bits, SelectEightDigitsPattern)
            .Select(digit => Convert.ToInt32(digit.ToString(), DefaultBase))
            .OrderBy(digit => digit)
            .Aggregate("", (currentDigit, nextDigit) => $"{currentDigit}{nextDigit}");
    }
}
