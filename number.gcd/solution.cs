using System;
using System.Collections.Generic;

namespace numbergcd;

class Cycle
{
    private static int Gcd(int num1, int num2)
    {
        int Remainder;

        while(num2 != 0)
        {
            Remainder = num1 % num2;
            num1 = num2;
            num2 = Remainder;
        }

        return num1;
    }

    static int Phi(int n)
    {
        int result = 1;
        for(int i = 2; i < n; i++)
            if(Gcd(i, n) == 1)
                result++;
        return result;
    }

    static int FastPhi(int n)
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

    //(number^degree) mod divider
    private static int GetModDivInNumberPowDegree(int number, int degree, int divider)
    {
        number %= divider;
        int result = 1;

        for(int i = 0; i < degree; ++i)
        {
            result = (result * number) % divider;
        }

        return result;

    }

    internal static int GetModDivInNumberPowDegreeByEiler(int number, int degree, int divider)
    {
        int eilerPhi = Phi(divider);
        degree %= eilerPhi;
        int result = (int)Math.Pow(number, degree) % divider;

        return result;
    }

    internal static int GetModDivInNumberPowDegreeByPredefinedPhi(int number, int degree, int divider, int phi)
    {
        degree %= phi;
        int result = (int)Math.Pow(number, degree) % divider;

        return result;
    }

    internal static int RunningOld(int n)
    {
        if(n == 3) return 1;

        if(Gcd(10, n) != 1) return -1;

        int phi_n = FastPhi(n);

        if(n - phi_n == 1) return phi_n;

        for(int i = 2; i <= phi_n; ++i)
        {
            //var result = GetModDivInNumberPowDegree(10, i, n);
            //var result = GetModDivInNumberPowDegreeByEiler(10, i, n);
            //var result = GetModDivInNumberPowDegreeByPredefinedPhi(10, i, n, phi_n);
            int degree = i % phi_n;

            var result = GetModDivInNumberPowDegree(10, degree, n);

            //int result = (int)Math.Pow(10, degree) % n;

            if(result == 10) return i - 1;
        }

        return -1;
    }

    internal static int Running(int number)
    {
        if(number % 2 == 0 || number % 5 == 0) return -1;

        var remain = 10;
        var remains = new HashSet<int>();

        for(int i = 0; i < number; ++i)
        {
            var floor = (int)Math.Floor(remain / (double)number);
            if(floor == 0)
            {
                remain *= 10;
            }
            else
            {
                remain = (remain - (floor * number)) * 10;
            }

            if(remains.Contains(remain))
            {
                return remains.Count;
            }
            else
            {
                remains.Add(remain);
            }
        }

        return -1;
    }
}
