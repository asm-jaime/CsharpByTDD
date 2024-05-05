using System;
using System.Collections.Generic;

namespace csharpclosure;

class Solution
{
    internal static string Calculate()
    {
        var result = string.Empty;
        var actions = new List<Action>();

        for(int i = 0; i < 5; i++)
        {
            actions.Add(() => result = $"{result}{i}");
        }

        foreach(var action in actions)
        {
            action();
        }

        return result;
    }
}
