using System.Collections.Generic;
using System.Linq;

namespace numberprimestreaming;

public class Primes
{
    public static List<int> GetPrimesByEratosfen(int maxNumber)
    {
        var isPrimeArray = new bool[maxNumber + 1];
        for(var i = 0; i < maxNumber + 1; i++) isPrimeArray[i] = true;

        isPrimeArray[0] = false;
        isPrimeArray[1] = false;

        for(var number = 2; number * number <= maxNumber; ++number)
        {
            if(isPrimeArray[number])
            {
                for(var step = number * number; step <= maxNumber; step = step + number)
                {
                    isPrimeArray[step] = false;
                }
            }
        }

        return isPrimeArray
            .Select((isPrime, index) => isPrime ? (int)index : (int)0)
            .Where(number => number > 0)
            .ToList();
    }

    public static IEnumerable<int> Stream()
    {
        return GetPrimesByEratosfen(100000);
    }
}
