namespace yandexcupalgorithms20242;

using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        while(t-- > 0)
        {
            int n = int.Parse(Console.ReadLine());
            long[] h = Console.ReadLine().Split().Select(long.Parse).ToArray();

            int[] inc = new int[n];
            int[] dec = new int[n];

            // Вычисляем inc[]
            inc[0] = 1;
            for(int i = 1; i < n; i++)
            {
                if(h[i] > h[i - 1])
                    inc[i] = inc[i - 1] + 1;
                else
                    inc[i] = 1;
            }

            // Вычисляем dec[]
            dec[n - 1] = 1;
            for(int i = n - 2; i >= 0; i--)
            {
                if(h[i] > h[i + 1])
                    dec[i] = dec[i + 1] + 1;
                else
                    dec[i] = 1;
            }

            long total = 0;
            for(int m = 0; m < n; m++)
            {
                if(inc[m] >= 2 && dec[m] >= 2)
                {
                    total += (long)(inc[m] - 1) * (dec[m] - 1);
                }
            }

            Console.WriteLine(total);
        }
    }
}
