using System;

namespace tinkofftariff;

public class Solution
{
    public int Calculate(int a, int b, int c, int d)
    {
        return Math.Max(a, a + (d - b) * c);
    }
}
