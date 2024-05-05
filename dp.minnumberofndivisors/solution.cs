using System;
using System.Collections.Generic;

namespace dpminnumberofndivisors;

class MinNbDiv
{
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
    internal static int FindMinNum(int num)
    {
        for(int i = 1; i <= num * num * num; i++)
        {
            if(GetAllDivisors(i).Length.Equals(num)) return i;
        }
        return 0;
    }
}
