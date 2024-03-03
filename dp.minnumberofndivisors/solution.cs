using System;
using System.Collections.Generic;

namespace dpminnumberofndivisors;

public class MinNbDiv
{
    public static int[] GetAllDivisors(int n)
    {
        int t = 0;
        List<int> result = new List<int>();
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
    public static int FindMinNum(int num)
    {
        for(int i = 1; i <= num * num * num; i++)
        {
            if(GetAllDivisors(i).Length.Equals(num)) return i;
        }
        return 0;
    }
}
