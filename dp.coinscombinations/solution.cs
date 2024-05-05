using System.Linq;

namespace dpcoinscombinations;

class Solution
{
    public static int CountCombinationsSlow(int moneys, int[] coins)
    {
        static int countChange(int moneys, int[] coins, int index)
        {
            if(moneys < 0 || (index == coins.Length && moneys > 0)) return 0;

            if(moneys == 0) return 1;

            return countChange(moneys - coins[index], coins, index) + countChange(moneys, coins, index + 1);

        }

        return countChange(moneys, coins, 0);
    }

    private static int GetForCurrentNominal(int nominal, int sumIndex, int nominalIndex, int[][] dpTable)
    {
        var result = dpTable[nominalIndex - 1][sumIndex];

        if(((sumIndex / nominal) * nominal).Equals(sumIndex)) result++;

        for(var number = 1; number * nominal < sumIndex; ++number)
        {
            if(dpTable[nominalIndex - 1][sumIndex - number * nominal].Equals(0)) continue;
            result += dpTable[nominalIndex - 1][sumIndex - number * nominal];
        }

        return result;
    }

    public static int CountCombinations(int moneys, int[] coins)
    {
        var dpTable = Enumerable.Range(0, coins.Length + 1).Select(coin => (new int[moneys + 1])).ToArray();

        for(var row = 1; row < dpTable.Length; ++row)
        {
            for(var col = 1; col < dpTable[row].Length; ++col)
            {
                dpTable[row][col] = GetForCurrentNominal(coins[row - 1], col, row, dpTable);
            }
        }

        return dpTable.LastOrDefault().LastOrDefault();
    }
}
