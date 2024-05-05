using System;
using System.Collections.Generic;
using System.Linq;

namespace maxsubsetsq;

class Solution
{
    internal static int MaximumLength(int[] nums)
    {
        var numTimesByNum = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (numTimesByNum.ContainsKey(num) is false)
            {
                numTimesByNum[num] = 0;
            }
            numTimesByNum[num]++;
        }

        Array.Sort(nums);

        var numSets = nums.Distinct().ToDictionary(num => num, num => new List<int>() { });

        foreach (var set in numSets)
        {
            if(set.Key == 1)
            {
                set.Value.AddRange(Enumerable.Range(0, numTimesByNum[set.Key] % 2 == 0? numTimesByNum[set.Key] - 1 : numTimesByNum[set.Key]).Select(e => 1).ToList());
                continue;
            }

            var setMultiple = set.Key;
            set.Value.Add(setMultiple);
            while(
                numTimesByNum.TryGetValue(setMultiple, out var numTime) &&
                numTime > 1 &&
                numTimesByNum.TryGetValue(setMultiple*setMultiple, out _)
            )
            {
                set.Value.Add(setMultiple);
                setMultiple *= setMultiple;
                set.Value.Add(setMultiple);
            }
        }

        return numSets.Max(set => set.Value.Count);
    }
}

