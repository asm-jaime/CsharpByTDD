using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace decodemorse;

class MorseCodeDecoder
{
    private static readonly Dictionary<string, string> MorseCode = new ()
        {
            {"", " " },
            {"-----", "0"}, {".----", "1"}, {"..---", "2"}, {"...--", "3"}, {"....-", "4"},
            {".....", "5"}, {"-....", "6"}, {"--...", "7"}, {"---..", "8"}, {"----.", "9"},
            {".-", "A"},
            {"-...", "B"},
            {"-.-.", "C"},
            {"-..", "D"},
            {".", "E"},
            {"..-.", "F"},
            {"--.", "G"},
            {"....", "H"},
            {"..", "I"},
            {".---", "J"},
            {"-.-", "K"},
            {".-..", "L"},
            {"--", "M"},
            {"-.", "N"},
            {"---", "O"},
            {".--.", "P"},
            {"--.-", "Q"},
            {".-.", "R"},
            {"...", "S"},
            {"-", "T"},
            {"..-", "U"},
            {"...-", "V"},
            {".--", "W"},
            {"-..-", "X"},
            {"-.--", "Y"},
            {"--..", "Z"},
            {".-.-.-", "."},
            {"--..--", ","},
            {"..--..", "?"},
            {".----.", "\'"},
            {"-.-.--", "!"},
            {"-..-.", "/"},
            {"-.--.", "("},
            {"-.--.-", ")"},
            {".-...", "&"},
            {"---...", ","},
            {"-.-.-.", ";"},
            {"-...-", "="},
            {".-.-.", "+"},
            {"-....-", "-"},
            {"..--.-", "_"},
            {".-..-.", "\""},
            {"...-..-", "$"},
            {".--.-.", "@"},
            {"...---...", "SOS"}
        };

    private static readonly Dictionary<string, string> BitsMorse = new()
    {
        { "1", "." },
        { "111", "-" }
    };

    private static string BitsTrim(string bits)
    {
        var fromIndex = bits.IndexOf('1');
        var lastIndex = bits.LastIndexOf('1');
        var cutLength = lastIndex - fromIndex + 1;

        if(fromIndex + lastIndex > 0)
        {
            return bits.Substring(fromIndex, cutLength);
        }

        return bits;
    }

    private static (string[], string[]) GetUnitsNulls(string bitStream)
    {
        List<string> nulls = new();
        List<string> units = new();
        StringBuilder buff = new();
        buff.Append(bitStream[0]);

        for(int i = 1; i < bitStream.Length; ++i)
        {
            if(bitStream[i].Equals(bitStream[i - 1]))
            {
                buff.Append(bitStream[i]);
                continue;
            }
            else if(bitStream[i - 1] == '0')
            {
                nulls.Add(buff.ToString());
                buff.Clear();
                buff.Append(bitStream[i]);
            }
            else if(bitStream[i - 1] == '1')
            {
                units.Add(buff.ToString());
                buff.Clear();
                buff.Append(bitStream[i]);
            }
        }
        if(buff[0] == '0') nulls.Add(buff.ToString());
        if(buff[0] == '1') units.Add(buff.ToString());

        return (nulls.ToArray(), units.ToArray());
    }

    internal static IEnumerable<string> DecodeBitsAdvanced(string bitStream)
    {
        StringBuilder morseCode = new();

        if(string.IsNullOrEmpty(bitStream) || bitStream.Contains('1').Equals(false))
            yield return morseCode.ToString();

        bitStream = BitsTrim(bitStream);

        var tries = 1;

        var (nulls, units) = GetUnitsNulls(bitStream);
        var isOnlyUnits = bitStream.All(oneBit => oneBit == '1');

        var minLength = 0;
        var maxUnitsLength = 0;

        if(isOnlyUnits)
        {
            minLength = maxUnitsLength = bitStream.Length;
        }
        else
        {
            minLength = Math.Min(units.Min(unit => unit.Length), nulls.Min(zeros => zeros.Length));
            maxUnitsLength = units.Max(unit => unit.Length);
        }

        var dots = new List<int>();
        var dashes = new List<int>();

        if(minLength == maxUnitsLength)
        {
            dots = Enumerable.Range(0, maxUnitsLength + 1).ToList();
            dashes = Enumerable.Range(0, 5 * maxUnitsLength + 1).ToList();
        }
        else
        {
            var maxNull = nulls.Max(zero => zero.Length);

            tries = Math.Max((int)Math.Ceiling(maxUnitsLength / 5.0), maxNull / 7);

            dots = Enumerable.Range(0, 2 * tries + 1).ToList();
            dashes = Enumerable.Range(0, 5 * tries + 1).ToList();
        }

        while(tries > 0)
        {
            var message = units
                .Select(unit => (dots.Contains(unit.Length) ? BitsMorse["1"] : BitsMorse["111"]))
                .ToArray();

            var intervals = nulls.Select((zeros, index) =>
            {
                if(dots.Contains(nulls[index].Length))
                {
                    return "";
                }
                else if(dashes.Contains(nulls[index].Length))
                {
                    return " ";
                }

                return "  ";
            });


            var signal = message
                .Zip(intervals.Append(""))
                .Select(strings => $"{strings.First}{strings.Second}")
                .Aggregate((first, second) => $"{first}{second}");

            dots = dots.SkipLast(1).ToList();
            dashes = dashes.SkipLast(3).ToList();

            yield return signal;
        }
    }

    internal static string DecodeMorse(IEnumerable<string> morseCodes)
    {

        foreach(var morseCode in morseCodes)
        {
            var symbols = morseCode
                .Split(new char[] { ' ' })
                .Select(code => MorseCode.TryGetValue(code, out var symbol) ? symbol : null);

            if(symbols.Any(string.IsNullOrEmpty)) continue;

            var decodedResult = symbols
                .Aggregate((first, second) => $"{first}{second}")
                .Trim()
                .Replace("   ", " ");

            return decodedResult;
        }

        return "";
    }
}
