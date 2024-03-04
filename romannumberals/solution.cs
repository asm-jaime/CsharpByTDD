using System.Collections.Generic;
using System.Linq;

namespace romannumberals;

public class RomanTransformer
{
    private static readonly string[] RomanDigits = new string[]
        { "I","V","X","L","C","D","M","N" };

    private int _currentIndex = 1;

    private string Current { get => RomanDigits[_currentIndex]; }
    private string Previous { get => RomanDigits[_currentIndex - 1]; }
    private string Next { get => RomanDigits[_currentIndex + 1]; }
    private void Proceed() => _currentIndex += 2;

    public string GetRoman(char digit)
    {
        string result = digit switch
        {
            '0' => "",
            '1' => $"{Previous}",
            '2' => $"{Previous}{Previous}",
            '3' => $"{Previous}{Previous}{Previous}",
            '4' => $"{Previous}{Current}",
            '5' => $"{Current}",
            '6' => $"{Current}{Previous}",
            '7' => $"{Current}{Previous}{Previous}",
            '8' => $"{Current}{Previous}{Previous}{Previous}",
            '9' => $"{Previous}{Next}",
            _ => "",
        };
        Proceed();

        return result;
    }
}

public static class NumberTransformer
{
    public static readonly Dictionary<string, int> RomanToNumber = new()
        {
            { "I", 1}, { "O", 4}, { "V", 5},
            { "P", 9}, { "X", 10}, { "Q", 40},
            { "L", 50}, { "R", 90}, { "C", 100},
            { "S", 400}, { "D", 500}, { "T", 900},
            { "M", 1000}
        };
    private static readonly Dictionary<string, string> DualRomanToSingleRoman = new()
        {
            { "IV",  "O"}, { "IX",  "P"}, { "XL",  "Q"},
            { "XC",  "R"}, { "CD",  "S"}, { "CM" , "T"},
        };

    public static int GetNumberFromRoman(string roman) => RomanToNumber[roman];

    public static string GetSingleRomanFromDual(string roman)
    {
        foreach(var dual in DualRomanToSingleRoman)
        {
            roman = roman.Replace(dual.Key, dual.Value);
        }

        return roman;
    }
}

public class RomanNumerals
{
    public static string ToRoman(int number)
    {
        var romaner = new RomanTransformer();

        return number
            .ToString()
            .ToCharArray()
            .Reverse()
            .Select(digit => romaner.GetRoman(digit))
            .Reverse()
            .Aggregate((first, next) => $"{first}{next}");
    }

    public static int FromRoman(string roman)
    {
        return NumberTransformer
            .GetSingleRomanFromDual(roman)
            .Select(romanChar => NumberTransformer.GetNumberFromRoman($"{romanChar}"))
            .Sum();
    }
}
