using System.Linq;

namespace csharpLINQ;


class Range
{
    int[] _numeric;

    internal Range()
    {
        _numeric = Enumerable.Range(1, 5).ToArray();
    }

    internal (int, string) GetSums()
    {
        var resSum = _numeric.Sum();
        var resNum2 = _numeric.Where(n => n < 4);

        return (resSum, string.Join(",", resNum2));
    }

    internal (int, string) ModifyNumericAndGetSums()
    {
        var resSum = _numeric.Sum();
        var resNum2 = _numeric.Where(n => n < 4);
        _numeric[2] = 0;
        return (resSum, string.Join(",", resNum2));
    }
}

