using System.Collections.Generic;

namespace parentheses;

class Parentheses
{
    private static readonly HashSet<char> OnPush = new() { '(' };
    private static readonly HashSet<char> OnPop = new() { ')' };

    internal static bool ValidParentheses(string input)
    {
        var allParentheses = input.ToCharArray();

        var checker = new Stack<char>();
        foreach(char parenthes in allParentheses)
        {
            if(OnPush.Contains(parenthes))
            {
                checker.Push(parenthes);
            }
            else if(OnPop.Contains(parenthes))
            {
                var isSuccess = checker.TryPop(out var _);
                if(isSuccess.Equals(false)) return false;
            }
        }

        var isEmpty = checker.Count.Equals(0);
        return isEmpty;
    }
}
