using System;

namespace tinkofftariff;

class Solution
{
    public static int Calculate(int a, int b, int c, int d)
    {
        return Math.Max(a, a + (d - b) * c);
    }
}
