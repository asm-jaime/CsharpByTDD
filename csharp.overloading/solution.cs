using System.Collections.Generic;

namespace csharpoverloading;

public class Car
{
    public string Model { get; set; }
    public int Wheels { get; set; }
}

public class Solution
{

    public static void RefreshValue(int value)
    {
        value = 0;
    }

    public static void RefreshValue(ref int value)
    {
        value = 0;
    }

    public static void RefreshValue(string value)
    {
        value = null;
    }

    public static void RefreshValue(List<string> value)
    {
        value = new List<string>();
        value.Add("I'm empty");
    }
}
