namespace csharprecords;

public record struct Point(int X, int Y);

class Solution
{
    public Point Calculate()
    {
        var point1 = new Point(1, 2);
        var point2 = point1 with { Y = 3 };

        return point2;
    }
}
