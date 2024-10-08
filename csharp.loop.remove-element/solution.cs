using System.Collections.Generic;

namespace csharploopremoveelement;

class Solution
{
    internal void LoopWrongRemove(List<int> list, int element)
    {
        foreach(var item in list)
        {
            if(item == element) list.Remove(item);
        }
    }

    internal void LoopRightRemove(List<int> list, int element)
    {
        for(int i = list.Count - 1; i >= 0; i--)
        {
            if(list[i] == element)
            {
                list.RemoveAt(i);
            }
        }
    }
}
