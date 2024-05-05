using System.Collections.Generic;
using System.Linq;

namespace finddigits;

class InfiniteDigitalString
{
    internal static long ParseTry(string num, int start, int step)
    {
        //console.log(num, "step=", step, "start=", start)
        long n;

        if(start + step <= num.Length)
        {
            n = long.Parse(num.Substring(start, (step)));
        }
        else
        {
            var p1 = num[start..];
            var p2 = num[..start];
            var common = p1.Length + p2.Length - step;
            _ = p2[common..];

            p1 += p2[common..];

            n = long.Parse(p1) + 1;

            if($"{n - 1}"[(step - p2.Length)..] != p2)
            {
                return -1;
            }

        }

        var tokens = new List<string>();
        var lena = 0;

        if(start > 0)
        {
            var prev = $"{n - 1}";
            tokens.Add(prev[^start..]);
            lena += start;
        }

        var x = n;
        while(lena < num.Length)
        {
            var stra = $"{x}";
            if(stra.Length + lena > num.Length)
            {
                tokens.Add(stra[..(num.Length - lena)]);
                lena += num.Length - lena;
            }
            else
            {
                tokens.Add(stra);
                lena += stra.Length;
            }
            x += 1;
        }

        if(string.Join("", tokens) == num)
        {
            var total = GetTotalLength(n);
            return total - start;
        }
        else
        {
            return -1;
        }
    }

    internal static long GetTotalLength(long n)
    {
        long total = 0;
        long lena = 1;
        long x = 10;

        while(n > x)
        {
            total += lena * (x - x / 10);
            x *= 10;
            lena += 1;
        }

        total += lena * (n - x / 10);
        return total;
    }

    internal static long FindPosition(string num)
    {
        //num = num.toString();
        var indexes = new List<long>();

        for(int step = 0; step < num.Length + 1; step++)
        {
            for(int start = 0; start < step; start++)
            {
                var index = ParseTry(num, start, step);
                //console.log(index);
                if(index >= 0)
                {
                    indexes.Add(index);
                }
            }
        }
        //console.log(indexes);
        if(indexes.Count == 0)
        {
            return GetTotalLength(long.Parse($"1{num}")) + 1;
        }

        return indexes.Min();
    }
}
