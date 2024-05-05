using System.Collections.Generic;

namespace csharpoverloading;

class Car
{
    internal string Model { get; set; }
    internal int Wheels { get; set; }
}

class Solution
{

    internal static void RefreshValue(int value)
    {
        value = 0;
    }

    internal static void RefreshValue(ref int value)
    {
        value = 0;
    }

    internal static void RefreshValue(string value)
    {
        value = null;
    }

    internal static void RefreshValue(List<string> value)
    {
        value = new List<string>();
        value.Add("I'm empty");
    }
}
