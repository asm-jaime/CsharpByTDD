using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace dptravellingsalesman;


[TestFixture]
class TSPTest
{
    [Test]
    public void T1_threePoints()
    {
        int[][] matrix = new int[][]
        {
          new int[]{0,176,463},
          new int[]{176,0,125},
          new int[]{463,125,0}
        };
        List<Int32> actual = TSP.Approximate(matrix);
        Assert.IsTrue(ValidCycle(actual, matrix), "Invalid route!");
        int dist = CalculateDistance(actual, matrix);
        Assert.IsTrue(dist <= 764, "Your route is " + dist + " long, but should be better or at least 764");
    }

    [Test]
    public void T2_eightPoints()
    {
        int[][] matrix = new int[][]
        {
            new int[]{0,343,482,294,452,406,118,68},
            new int[]{343,0,3,129,115,165,45,15},
            new int[]{482,3,0,397,148,488,335,79},
            new int[]{294,129,397,0,32,135,318,310},
            new int[]{452,115,148,32,0,467,70,303},
            new int[]{406,165,488,135,467,0,83,63},
            new int[]{118,45,335,318,70,83,0,421},
            new int[]{68,15,79,310,303,63,421,0},
        };
        List<Int32> actual = TSP.Approximate(matrix);
        Assert.IsTrue(ValidCycle(actual, matrix), "Invalid route!");
        int dist = CalculateDistance(actual, matrix);
        Assert.IsTrue(dist <= 602, "Your route is " + dist + " long, but should be better or at least 602");
    }

    [Test]
    public void T3_thirdteenPoints()
    {
        int[][] matrix = new int[][]
        {
            new int[]{0,236,237,134,1,31,4,350,63,478,414,361,328},
            new int[]{236,0,458,46,148,401,434,168,458,332,205,171,214},
            new int[]{237,458,0,405,249,220,72,80,149,494,116,470,175},
            new int[]{134,46,405,0,15,235,453,149,100,313,118,392,277},
            new int[]{1,148,249,15,0,122,356,43,182,263,281,484,187},
            new int[]{31,401,220,235,122,0,294,144,444,263,331,154,402},
            new int[]{4,434,72,453,356,294,0,96,469,245,465,336,299},
            new int[]{350,168,80,149,43,144,96,0,171,387,390,66,109},
            new int[]{63,458,149,100,182,444,469,171,0,314,281,420,39},
            new int[]{478,332,494,313,263,263,245,387,314,0,254,323,243},
            new int[]{414,205,116,118,281,331,465,390,281,254,0,130,382},
            new int[]{361,171,470,392,484,154,336,66,420,323,130,0,240},
            new int[]{328,214,175,277,187,402,299,109,39,243,382,240,0},
        };
        List<Int32> actual = TSP.Approximate(matrix);
        Assert.IsTrue(ValidCycle(actual, matrix), "Invalid route!");
        int dist = CalculateDistance(actual, matrix);
        Assert.IsTrue(dist <= 1441, "Your route is " + dist + " long, but should be better or at least 1441");
    }

    private static bool ValidCycle(List<Int32> actual, int[][] matrix)
    {
        if(actual.Count - 1 != matrix.Length)
            return false;
        List<Int32> l = new(actual);
        l.Sort((a, b) => a - b);
        if(l[0] != 0)
            return false;
        for(int i = 1; i < l.Count; i++)
        {
            if(l[i] != i - 1)
                return false;
        }
        return true;
    }

    private static int CalculateDistance(List<Int32> l, int[][] matrix)
    {
        int distance = 0;
        for(int i = 0; i < l.Count - 1; i++)
        {
            distance += matrix[l[i]][l[i + 1]];
        }
        return distance;
    }
}
