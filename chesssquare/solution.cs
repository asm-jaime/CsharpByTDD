using System;

namespace chesssquare;

public class Solution
{
    public static int SUMA002378(int n) => (n - 1) * (n) * (n + 1) / 3;

    public static int StableCrossSize(int x, int y) => Math.Abs(x - y) + 1;

    public static int SquaresVerticalHorizontal(int x, int y) => x * y * (x + y - 2);

    public static int SquaresOneCross(int x, int y)
    {
        var unstableCross = SUMA002378(Math.Min(x, y) - 1);
        var stableCross = StableCrossSize(x, y) * Math.Min(x, y) * (Math.Min(x, y) - 1);
        return 2 * unstableCross + stableCross;
    }

    public static int ChessboardSquaresUnderQueenAttack(int x, int y)
    {
        return SquaresVerticalHorizontal(x, y) + 2 * SquaresOneCross(x, y);
    }
}
