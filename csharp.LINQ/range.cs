using System.Linq;

namespace csharpLINQ;


public class Range
{
    int[] _numeric;

    public Range()
    {
        _numeric = Enumerable.Range(1, 5).ToArray();
    }

    public (int, string) GetSums()
    {
        var resSum = _numeric.Sum();
        var resNum2 = _numeric.Where(n => n < 4);

        return (resSum, string.Join(",", resNum2));
    }

    public (int, string) ModifyNumericAndGetSums()
    {
        var resSum = _numeric.Sum();
        var resNum2 = _numeric.Where(n => n < 4);
        _numeric[2] = 0;
        return (resSum, string.Join(",", resNum2));
    }
}

