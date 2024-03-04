using System.Numerics;

namespace fibbonaccirecursive;

public class Fibonacci
{
    public static (BigInteger, BigInteger) GetFibRecursive(int num)
    {
        if(num.Equals(0)) return (BigInteger.Zero, BigInteger.One);
        if(num.Equals(1)) return (BigInteger.One, BigInteger.One);

        (BigInteger a, BigInteger b) = GetFibRecursive(num / 2);
        BigInteger p = a * (2 * b - a);
        BigInteger q = b * b + a * a;

        if(num % 2 == 0) return (p, q);

        return (q, p + q);
    }

    public static BigInteger Fib(int n)
    {
        int sign = n < 0 && n % 2 == 0 ? -1 : 1;
        n = n < 0 ? -n : n;

        (BigInteger result, _) = GetFibRecursive(n);

        return result * sign;
    }
}
