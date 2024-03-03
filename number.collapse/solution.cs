using System;

namespace numbercollapse;

public class RangeCollapse
{
    public int Descriptions(int[] arr)
    {
        int result = 1;
        int currentGroup = 0;
        for(int index = 1; index < arr.Length; index++)
        {
            if(arr[index] - arr[index - 1] == 1)
            {
                currentGroup++;
            }
            else
            {
                result = result * (int)Math.Pow(2, currentGroup);
                currentGroup = 0;
            }

        }
        result = result * (int)Math.Pow(2, currentGroup);

        return result;
    }
}
