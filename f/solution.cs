using System;

namespace f;

public class Solution
{
    private (int, int) GetGoodEvenEvenPair(int[] heights)
    {
        int first = -1;
        int second = -1;

        for (int i = 0; i < heights.Length; ++i)
        {
            // Find index of an odd number at odd position or even number at even position
            if ((i + 1) % 2 != 0 && heights[i] % 2 != 0)
            {
                if (first != -1) { second = i; break; }
                first = i;
            }
        }

        return (second, first);
    }

    private (int, int) GetBadEvenOddOrOddEvenPair(int[] heights)
    {
        int oddId = -1;
        int evenId = -1;
        for (int i = 0; i < heights.Length; i++)
        {
            // Find index of an odd number at even position or even number at odd position
            if ((i + 1) % 2 == 0 && heights[i] % 2 != 0 && evenId == -1)
            {
                evenId = i;
                if (oddId != -1) break;
            }
            else if ((i + 1) % 2 != 0 && heights[i] % 2 == 0 && oddId == -1)
            {
                oddId = i;
                if (evenId != -1) break;
            }
        }
        return (oddId, evenId);
    }

    private bool IsHereMoreForSwap(int[] heights)
    {

        for (int i = 0; i < heights.Length; i++)
        {
            if (((i + 1) % 2 == 0 && heights[i] % 2 != 0) || ((i + 1) % 2 != 0 && heights[i] % 2 == 0))
            {
                return true;
            }
        }
        return false;
    }

    public int[] SwapPositions(int[] heights)
    {
        var result = new int[] { -1, -1 };
        // Get pair index for swap
        var (oddId, evenId) = GetBadEvenOddOrOddEvenPair(heights);

        // Check if pair not found, and if here nothing wrong to swap, let's do unnecessary swap
        if (oddId == -1 && evenId == -1) (oddId, evenId) = GetGoodEvenEvenPair(heights);

        // Check if pair found and swap it
        if (oddId != -1 && evenId != -1)
        {
            Swap(heights, oddId, evenId);
            result = new int[] { Math.Min(oddId + 1, evenId + 1), Math.Max(oddId + 1, evenId + 1) };
        }

        if (IsHereMoreForSwap(heights)) return new int[] { -1, -1 }; // It's not possible to make a swap

        return result;
    }

    public void Swap(int[] heights, int from, int to)
    {
        (heights[from], heights[to]) = (heights[to], heights[from]);
    }
}
