using System;

namespace cubesum;

class CubeSum
{
    // private static bool isDecimalPartExist(double number) => number - Math.Truncate(number) > 0;

    /*
    private static bool isSquareable(long number)
    {
        long sqrt = (long)Math.Sqrt(number);
        return sqrt * sqrt == number;
    }
    */

    public static long FindNb(long m)
    {
        // m = n^2*(n+1)^2/4
        // sqrt(m) = n*(n+1)/2
        // n^2 + n - 2*sqrt(m) = 0
        // det = 1^2 - 4*1*(-2*sqrt(m))
        // det = 1 + 8*sqrt(m)
        // x1 = -1 + sqrt(det)/2
        long x1 = (long)((-1 + Math.Sqrt(1 + 8 * Math.Sqrt(m))) / 2);
        long checkNumber = x1 * x1 * (x1 + 1) * (x1 + 1) / 4;

        if(checkNumber == m)
        {
            return x1;
        }

        return -1;
    }
}
