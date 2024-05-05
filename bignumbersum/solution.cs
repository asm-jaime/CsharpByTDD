using System.Linq;

namespace bignumbersum;

class Solution
{
    internal static string Add(string a, string b)
    {
        var charsA = a.ToCharArray().Reverse().ToArray();
        var charsB = b.ToCharArray().Reverse().ToArray();
        (var firstChars, var secondChars) = charsA.Length > charsB.Length ? (charsA, charsB) : (charsB, charsA);

        int remain = 0;
        var result = firstChars.Select((firstDigit, indexer) =>
        {
            int secondNumber = indexer < secondChars.Length ? secondChars[indexer] - '0' : 0;
            int firstNumber = firstDigit - '0';
            int sum = firstNumber + secondNumber + remain;
            int current = sum % 10;
            remain = sum / 10;

            return (char)(current + '0');
        }).ToList();

        if(remain != 0) result.Add((char)(remain + '0'));

        result.Reverse();

        return new string(result.ToArray());
    }
}
