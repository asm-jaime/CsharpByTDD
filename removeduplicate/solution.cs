using System;
using System.Linq;

namespace removeduplicate;


class DistinctByHashSet
{
    public int[] Calculate(int[] array)
    {
        return array.ToHashSet().ToArray();
    }
}

class DistinctBySort
{
    public int[] Calculate(int[] array)
    {
        Array.Sort(array);
        for(var i = 1; i < array.Length; ++i)
        {
            if(array[i] == array[i - 1])
            {
                array[i] = default;
            }
        }

        return array;
    }
}
