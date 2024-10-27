using System;
using System.Numerics;

namespace yandexcupalgorithms20241
{
    class Solution
    {
        private BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        private BigInteger LCM(BigInteger a, BigInteger b)
        {
            return a / GCD(a, b) * b;
        }

        internal BigInteger Calculate(int a, int b, int c, BigInteger n)
        {
            BigInteger lcm_ab = LCM(a, b);
            BigInteger lcm_ac = LCM(a, c);
            BigInteger lcm_bc = LCM(b, c);
            BigInteger lcm_abc = LCM(a, LCM(b, c));

            // Проверка на пустую последовательность
            if (lcm_ab == lcm_abc && lcm_ac == lcm_abc && lcm_bc == lcm_abc)
            {
                return -1;
            }

            BigInteger left = 1;
            BigInteger right = BigInteger.Pow(10, 20); // Увеличиваем правую границу

            BigInteger answer = -1;

            while (left <= right)
            {
                BigInteger mid = (left + right) / 2;
                BigInteger count = mid / lcm_ab + mid / lcm_ac + mid / lcm_bc - 3 * (mid / lcm_abc);

                if (count >= n)
                {
                    if (mid <= BigInteger.Pow(10, 18))
                    {
                        answer = mid;
                    }
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            BigInteger n;
            string[] input = Console.ReadLine().Split();
            a = int.Parse(input[0]);
            b = int.Parse(input[1]);
            c = int.Parse(input[2]);
            n = BigInteger.Parse(Console.ReadLine());

            var solution = new Solution();
            var result = solution.Calculate(a, b, c, n);

            Console.WriteLine(result);
        }
    }
}

