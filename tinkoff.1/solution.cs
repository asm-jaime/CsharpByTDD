using System;

namespace tinkoff1;

public class Solution
{
    public int ScoreDarts(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        return ScoreThrow(x1, y1) + ScoreThrow(x2, y2) + ScoreThrow(x3, y3);
    }

    private int ScoreThrow(double x, double y)
    {
        double distance = Math.Sqrt(x * x + y * y);
        if (distance <= 0.1) return 3;
        if (distance <= 0.8) return 2;
        if (distance <= 1.0) return 1;
        return 0;
    }
}


