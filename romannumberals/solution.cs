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
    private void Proceed() => _currentIndex = _currentIndex + 2;

    public string GetRoman(char digit)
    {
        string result = "";

        switch(digit)
        {
            case '0': result = ""; break;
            case '1': result = $"{Previous}"; break;
            case '2': result = $"{Previous}{Previous}"; break;
            case '3': result = $"{Previous}{Previous}{Previous}"; break;
            case '4': result = $"{Previous}{Current}"; break;
            case '5': result = $"{Current}"; break;
            case '6': result = $"{Current}{Previous}"; break;
            case '7': result = $"{Current}{Previous}{Previous}"; break;
            case '8': result = $"{Current}{Previous}{Previous}{Previous}"; break;
            case '9': result = $"{Previous}{Next}"; break;
            default: result = ""; break;
        }

        Proceed();

        return result;
    }
}

public static class NumberTransformer
{
    public static readonly Dictionary<string, int> RomanToNumber = new Dictionary<string, int>()
        {
            { "I", 1}, { "O", 4}, { "V", 5},
            { "P", 9}, { "X", 10}, { "Q", 40},
            { "L", 50}, { "R", 90}, { "C", 100},
            { "S", 400}, { "D", 500}, { "T", 900},
            { "M", 1000}
        };
    private static readonly Dictionary<string, string> DualRomanToSingleRoman = new Dictionary<string, string>()
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
