using NUnit.Framework;
using System;
using System.Linq;

namespace snail;


[TestFixture]
public class SnailTest
{
    [Test]
    public void SnailTest1()
    {
        int[][] array = {
                new []{1, 2, 3},
                new []{4, 5, 6},
                new []{7, 8, 9}
            };
        var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
        Test(array, r);
    }

    [Test]
    public void SnailTest2()
    {
        int[][] array = {
                new []{582,530,821,206,352},
                new []{178,132,332,849,20},
                new []{359,22,840,818,453},
                new []{257,822,247,405,655},
                new []{577,985,471,279,459},
            };
        var r = new[] { 582, 530, 821, 206, 352, 20, 453, 655, 459, 279, 471, 985, 577, 257, 359, 178, 132, 332, 849, 818, 405, 247, 822, 22, 840 };
        Test(array, r);
    }

    public static string Int2dToString(int[][] a)
    {
        return $"[{string.Join("\n", a.Select(row => $"[{string.Join(",", row)}]"))}]";
    }

    public static void Test(int[][] array, int[] result)
    {
        var text = $"{Int2dToString(array)}\nshould be sorted to\n[{string.Join(",", result)}]\n";
        Console.WriteLine(text);
        Assert.AreEqual(result, SnailSolution.Snail(array));
    }
}
