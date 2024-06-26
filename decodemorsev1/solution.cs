﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace decodemorsev1;

class MorseCodeDecoder
{
    internal static string BitsTrim(string bits)
    {
        var fromIndex = bits.IndexOf('1');
        var lastIndex = bits.LastIndexOf('1');

        if(fromIndex + lastIndex > 0)
        {
            return bits[fromIndex..lastIndex];
        }

        return bits;
    }

    internal static int DecodeBitsLength(string bits)
    {
        var _bits = BitsTrim(bits);
        var arrOf1 = Regex.Split(_bits, "0{1,99}");
        Array.Sort(arrOf1);
        if(arrOf1.Length == 0)
        {
            return 1;
        }
        int _result = arrOf1[0].Length;

        var arrOf0 = Regex.Split(_bits, "1{1,99}");

        if(arrOf0.Length > 2)
        {
            if(arrOf0[1].Length < _result)
            {
                _result = arrOf0[1].Length;
            }
        }
        return _result;
    }
    internal static string DecodeBitsAdvanced(string bits)
    {
        // ToDo: Accept 0's and 1's, return dots, dashes and spaces

        int length = DecodeBitsLength(bits);

        int lengthOfDash = 3 * length;
        int lengthOfDot = 1 * length;
        int lengthOfLongSpace = 7 * length;
        int lengthOfSpace = 3 * length;
        var output = bits;

        output = Regex.Replace(output, @"1{" + lengthOfDash + @"}", "-");
        output = Regex.Replace(output, @"1{" + lengthOfDot + @"}", ".");
        output = Regex.Replace(output, @"0{" + lengthOfLongSpace + @",99}", "   ");
        output = Regex.Replace(output, @"0{" + lengthOfSpace + @"}", " ");
        output = Regex.Replace(output, @"0*", "");

        return output;
    }

    internal static string DecodeMorse(string morseCode)
    {
        string[] morseCodeWords = morseCode.Split("   ");
        string output = "";

        foreach(string morseWord in morseCodeWords)
        {
            string[] morseLetters = morseWord.Split(" ");
            string outputWord = "";

            foreach(string morseLetter in morseLetters)
            {
                outputWord += morse.FirstOrDefault(x => x.Value == morseLetter).Key;
                // outputWord += MorseCode.Get(morseLetter); for codewars
            }

            output += (output == "") ? outputWord : " " + outputWord;
        }

        return output;
    }

    static readonly Dictionary<char, string> morse = new()
        {
          {'0' , "-----"}, {'1' , ".----"}, {'2' , "..---"}, {'3' , "...--"}, {'4' , "....-"},
          {'5' , "....."}, {'6' , "-...."}, {'7' , "--..."}, {'8' , "---.."}, {'9' , "----."},
          {'A' , ".-"},
          {'B' , "-..."},
          {'C' , "-.-."},
          {'D' , "-.."},
          {'E' , "."},
          {'F' , "..-."},
          {'G' , "--."},
          {'H' , "...."},
          {'I' , ".."},
          {'J' , ".---"},
          {'K' , "-.-"},
          {'L' , ".-.."},
          {'M' , "--"},
          {'N' , "-."},
          {'O' , "---"},
          {'P' , ".--."},
          {'Q' , "--.-"},
          {'R' , ".-."},
          {'S' , "..."},
          {'T' , "-"},
          {'U' , "..-"},
          {'V' , "...-"},
          {'W' , ".--"},
          {'X' , "-..-"},
          {'Y' , "-.--"},
          {'Z' , "--.."},
        };

}

