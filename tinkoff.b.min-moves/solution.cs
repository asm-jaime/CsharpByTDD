using System;

namespace b
{
    public class Solution
    {
        public int GetMinimalCrosses(int pieces)
        {
            double log2 = Math.Log2(pieces);
            bool hasFraction = log2 % 1 != 0;
            int result = (int) log2;

            if (hasFraction) return result + 1;
            return result;
        }
    }
}
