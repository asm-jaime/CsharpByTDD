using System.Linq;

namespace numberpersistent;

class Persist
{
    private static long MultipleDigits(long number) =>
      number
      .ToString()
      .Select(digit => digit - '0')
      .Aggregate((first, second) => first * second);

    internal static int Persistence(long n)
    {
        int result = 0;

        while(n / 10 > 0)
        {
            n = MultipleDigits(n);
            result++;
        }

        return result;
    }
}
