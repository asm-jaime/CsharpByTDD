using System;
using System.Linq;
using System.Numerics;

namespace numberlastdigit;



class Calculator
{
    public static int GetLastDigit(int[] array, int m)
    {
        BigInteger result = 1;
        foreach(var num in array.Reverse())
        {
            if(result >= 4) result = result % 4 + 4;
            result = BigInteger.Pow(num, (int)result);
        }
        return (int)(result % m);
    }

    public static int LastDigit(int[] array)
    {
        return GetLastDigit(array, 10);
    }
}
