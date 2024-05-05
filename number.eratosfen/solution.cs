using System;
using System.Collections.Generic;
using System.Linq;

namespace numbereratosfen;

class NumberEratosfen
{
    private readonly List<int> _primes;

    internal NumberEratosfen(int MaxNumber)
    {
        _primes = new List<int>();
        for(int i = 1; i < MaxNumber; i++)
            _primes.Add(i);
        DoEratosfen();
    }

    private int Step(int Prime, int startFrom)
    {
        int i = startFrom + 1;
        int removed = 0;
        while(i < _primes.Count)
            if(_primes[i] % Prime == 0)
            {
                _primes.RemoveAt(i);
                removed++;
            }
            else i++;

        return removed;
    }

    void DoEratosfen()
    {
        int i = 1;
        while(i < _primes.Count)
        {
            Step(_primes[i], i);
            i++;
        }
    }

    internal int[] Primes
    {
        get
        {
            return _primes.ToArray();
        }
    }

}

internal static class Divisors
{

    private static readonly HashSet<int> _primeNumbers = GetPrimesByEratosfen(100000);

    // private static readonly Dictionary<int, Dictionary<int, int>> _numberDivisors = new();

    private static HashSet<int> GetPrimesByEratosfen(int maxNumber)
    {
        //_primeNumbers.Con
        var isPrimeArray = new bool[maxNumber + 1];
        for(var i = 0; i < maxNumber + 1; i++) isPrimeArray[i] = true;

        isPrimeArray[0] = false;
        isPrimeArray[1] = false;

        for(var number = 2; number * number <= maxNumber; ++number)
        {
            if(isPrimeArray[number])
            {
                for(var step = number * number; step <= maxNumber; step += number)
                {
                    isPrimeArray[step] = false;
                }
            }
        }

        return isPrimeArray
            .Select((isPrime, index) => isPrime ? (int)index : (int)0)
            .Where(number => number > 0)
            .ToHashSet();
    }

    internal static List<int> GetAllPrimeFactors(int n)
    {
        var map = new Dictionary<int, int>();
        var result = new List<int>();
        if(n.Equals(0)) return result;
        if(n.Equals(1)) { result.Add(n); return result; };
        if(n.Equals(2)) { result.Add(n); return result; }

        var number = n;
        foreach(var divisor in _primeNumbers)
        {
            if(divisor.Equals(1)) continue;
            if(number < 2) break;
            if(number < divisor) break;
            if(_primeNumbers.Contains(number))
            {
                if(map.ContainsKey(number))
                {
                    map[number]++;
                }
                else
                {
                    map[number] = 1;
                }
                break;
            }

            while(number % divisor == 0)
            {
                if(map.ContainsKey(divisor)) map[divisor]++;
                else map[divisor] = 1;

                number /= divisor;
            }
        }

        result = map
            .Select(el => Enumerable.Range(0, el.Value).Select(_ => el.Key).ToList())
            .Aggregate((acc, el) => { acc.AddRange(el); return acc; })
            .ToList();

        return result;
    }

    internal static int[] GetAllDivisors(int n)
    {
        List<int> result = new();
        for(int i = 1; i <= Math.Sqrt(n); i++)
        {
            if(n % i == 0)
            {
                if(n / i == i)
                {
                    result.Add(i);
                }
                else
                {
                    result.Add(i);
                    result.Add(n / i);
                }
            }
        }
        return result.ToArray();
    }
}

class NumberTheory
{
    /*
    internal List<BigInteger> GetCoprimeFactors(BigInteger n, int m)
    {
        var result = new List<BigInteger>() { n };
        if (result.Last().Equals(0)) return result;
        if (result.Last().Equals(1)) return result;
        if (result.Last().Equals(2)) return result;
        if (result.Last().Equals(3)) return result;

        var primeIndex = 1;
        while (Gcd(result.Last(), m) != 1)
        {
            var divisor = _primeNumbers[primeIndex];
            //if (divisor.Equals(1)) continue;

            var last = result.Last();
            var remain = last % divisor;
            if (remain.Equals(0))
            {
                last = last / divisor;
                //125 = 5(divisor)*25(last)
                result.RemoveAt(result.Count - 1);
                result.Add(divisor);
                result.Add(last);
            }
            else
            {
                primeIndex++;
            }
        }


        return result;
    }
    */
    /*
    private static BigInteger Gcd(BigInteger num1, BigInteger num2)
    {
        BigInteger Remainder;

        while (num2 != 0)
        {
            Remainder = num1 % num2;
            num1 = num2;
            num2 = Remainder;
        }

        return num1;
    }
    */

    /*
    private static HashSet<long> GetPrimesByEratosfen(long maxNumber)
    {
        var isPrimeArray = new bool[maxNumber + 1];
        for(var i = 0; i < maxNumber + 1; i++) isPrimeArray[i] = true;

        isPrimeArray[0] = false;
        isPrimeArray[1] = false;

        for(var number = 2; number * number <= maxNumber; ++number)
        {
            if(isPrimeArray[number])
            {
                for(var step = number * number; step <= maxNumber; step += number)
                {
                    isPrimeArray[step] = false;
                }
            }
        }

        return isPrimeArray
            .Select((isPrime, index) => isPrime ? (long)index : (long)0)
            .Where(number => number > 0)
            .ToHashSet();
    }
    */
}

internal static class ChineseRemainderTheorem
{
    internal static int Solve(int[] a, int[] n)
    {
        int prod = n.Aggregate(1, (i, j) => i * j);
        int p;
        int sm = 0;
        for(int i = 0; i < n.Length; i++)
        {
            p = prod / n[i];
            sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
        }
        return sm % prod;
    }

    private static int ModularMultiplicativeInverse(int a, int mod)
    {
        int b = a % mod;
        for(int x = 1; x < mod; x++)
        {
            if((b * x) % mod == 1)
            {
                return x;
            }
        }
        return 1;
    }
}

internal static class EulerTheorem
{
    internal static int Gcd(int num1, int num2)
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
    internal static int Totient(int n)
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
}

