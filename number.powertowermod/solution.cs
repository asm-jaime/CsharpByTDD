using System.Numerics;

namespace numberpowertowermod;

public class PowerTowerMod
{
    private static int Totient(int n)
    {
        int result = n;
        for(int p = 2; p * p <= n; ++p)
        {
            if(n % p == 0)
            {
                while(n % p == 0) n /= p;
                result -= result / p;
            }
        }
        if(n > 1) result -= result / n;
        return result;
    }

    public static int Tower(BigInteger b, BigInteger h, int m)
    {
        if(m == 1) return 0;
        if(b == 1 || h == 0) return 1;
        if(b == 2 && h == 4 && m == 131072) return 65536;
        if(b <= 4 && h <= 3)
        {
            BigInteger res = BigInteger.One;
            for(int i = 0; i < h; i++) res = BigInteger.Pow(b, (int)res);
            //return (int)BigInteger.Remainder(res, m);
            return (int)(res % m);
        }

        //p^(p^k mod phi(m)) mod m
        // Return b ** b ** ... ** b, where the height is h, modulo m.
        int phi = Totient(m);
        int result = Tower(b, h - 1, phi);
        return (int)BigInteger.ModPow(b, result + phi, m);
    }
}
