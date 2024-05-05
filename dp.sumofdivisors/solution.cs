using System;
using System.Collections.Generic;
using System.Linq;

namespace dpsumofdivisors;

class ThirdPow
{
    private static readonly HashSet<long> _primeNumbers;

    private static readonly Dictionary<long, Dictionary<long, long>> _numberDivisors = new();

    internal static HashSet<long> GetPrimesByEratosfen(long maxNumber)
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

    static ThirdPow()
    {
        _primeNumbers = GetPrimesByEratosfen(100000);
    }

    internal static long GetSumOfPrimeFactors(Dictionary<long, long> primeFactors)
    {
        long result = 1;
        foreach(var primeFactor in primeFactors)
        {
            result *= (((int)Math.Pow(primeFactor.Key, primeFactor.Value + 1) - 1) / (primeFactor.Key - 1));
        }

        return result;
    }

    internal static Dictionary<long, long> GetAllPrimeFactors(long n)
    {
        var result = new Dictionary<long, long>();
        if(n.Equals(0)) return result;
        if(n.Equals(1)) return result;
        if(n.Equals(2)) { result[2] = 1; return result; }

        var number = n;
        foreach(var divisor in _primeNumbers)
        {
            if(divisor.Equals(1)) continue;
            if(number < 2) break;
            if(number < divisor) break;
            if(_primeNumbers.Contains(number))
            {
                if(result.ContainsKey(number))
                {
                    result[number]++;
                }
                else
                {
                    result[number] = 1;
                }
                break;
            }


            if(_numberDivisors.ContainsKey(number))
            {
                var chachedDivisors = _numberDivisors[number];
                foreach(var primeFactor in chachedDivisors)
                {
                    var primeNumber = primeFactor.Key;
                    if(result.ContainsKey(primeNumber))
                    {
                        result[primeNumber] = result[primeNumber] + primeFactor.Value;
                    }
                    else
                    {
                        result[primeNumber] = primeFactor.Value;
                    }
                    //result[primeFactor]
                }
                break;
            }

            while(number % divisor == 0)
            {
                if(result.ContainsKey(divisor)) result[divisor]++;
                else result[divisor] = 1;

                number /= divisor;
            }
        }


        return result;
    }

    internal static long GetAllDivisors(long n)
    {
        var primeFactors = GetAllPrimeFactors(n);
        _numberDivisors[n] = primeFactors;

        return GetSumOfPrimeFactors(primeFactors);
    }


    internal static long IntCubeSumDiv(long n)
    {

        long numberCounter = 0;
        long number = 0;
        while(numberCounter <= n)
        {
            number++;
            var div = Math.Pow(number, 3) / GetAllDivisors(number);
            var longegralPartDivide = (long)div;
            if(((double)longegralPartDivide).Equals(div)) numberCounter++;
        }
        return number;
    }
}
