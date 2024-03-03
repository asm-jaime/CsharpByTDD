using System;

namespace bitcount;

public class Solution
{
    public int CountBits(int number)
    {
        int result = 0;
        int bits = (int)Math.Ceiling(Math.Log2(number));
        for(int bit = 0; bit <= bits; ++bit)
        {
            if(((byte)(number >> bit) & 1) == 1)
            {
                result++;
            }
        }
        return result;
    }
}
