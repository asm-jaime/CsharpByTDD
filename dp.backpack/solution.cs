using System;

namespace dpbackpack;

class DPBackpackTask
{
    public static int PackBagpack(int[] scores, int[] weights, int capacity)
    {
        var packs = new int[weights.Length, capacity + 1];

        for(int weightIndex = 0; weightIndex < weights.Length; ++weightIndex)
        {
            for(int currentWeight = 0; currentWeight <= capacity; ++currentWeight)
            {
                if(currentWeight == 0)
                {
                    packs[weightIndex, currentWeight] = 0;
                    continue;
                }
                if(weightIndex == 0 && weights[weightIndex] > currentWeight)
                {
                    packs[weightIndex, currentWeight] = 0;
                    continue;
                }
                if(weightIndex == 0 && weights[weightIndex] <= currentWeight)
                {
                    packs[weightIndex, currentWeight] = scores[weightIndex];
                    continue;
                }

                if(currentWeight < weights[weightIndex])
                {
                    packs[weightIndex, currentWeight] = packs[weightIndex - 1, currentWeight];
                }
                else
                {
                    packs[weightIndex, currentWeight] =
                        Math.Max(
                            packs[weightIndex - 1, currentWeight - weights[weightIndex]] + scores[weightIndex],
                            packs[weightIndex - 1, currentWeight]
                        );
                }
            }
        }

        return packs[weights.Length - 1, capacity];
    }
}
