using System.Linq;

namespace e
{
    public class SolutionSlow
    {
        public static long CountSameDigitsNumbers(long start, long end)
        {
            long maxTests = 0;
            for (long i = start; i <= end; i++)
            {
                if (HasSameDigits(i)) maxTests++;
            }
            return maxTests;
        }

        private static bool HasSameDigits(long n)
        {
            long digit = n % 10;
            while (n > 0)
            {
                if (n % 10 != digit) return false;
                n /= 10;
            }
            return true;
        }
    }

    public class Solution
    {
        private static long CountSameDigitsNumber(long number)
        {
            var strNum = number.ToString();
            var digit = strNum.First() - '0';
            var sameDigitA = long.Parse(new string(strNum.First(), strNum.Length));
            long result = digit  + 9 * (strNum.Length - 1);

            if(sameDigitA > number) result--;

            return result;

        }
        public static long CountSameDigitsNumbers(long a, long b)
        {
            var (strA, strB) = (a.ToString(), b.ToString());

            if (strA.Length == strB.Length && strA.Length == 1) return b - a + 1;

            var (first, second) = (CountSameDigitsNumber(a - 1), CountSameDigitsNumber(b));

            return second - first;
        }
    }
}
