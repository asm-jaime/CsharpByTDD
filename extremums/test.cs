using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace extremums;


[TestFixture]
class SolutionTest
{

    private static readonly string[] msg =
    {
        "should support finding peaks",
        "should support finding peaks, but should ignore peaks on the edge of the array",
        "should support finding peaks; if the peak is a plateau, it should only return the position of the first element of the plateau",
        "should support finding peaks; if the peak is a plateau, it should only return the position of the first element of the plateau",
        "should support finding peaks, but should ignore peaks on the edge of the array"
    };

    private static readonly int[][] array =
    {
        new int[]{1,2,3,6,4,1,2,3,2,1},
        new int[]{3,2,3,6,4,1,2,3,2,1,2,3},
        new int[]{3,2,3,6,4,1,2,3,2,1,2,2,2,1},
        new int[]{2,1,3,1,2,2,2,2,1},
        new int[]{2,1,3,1,2,2,2,2}
    };

    private static readonly int[][] posS =
    {
        new int[]{3,7},
        new int[]{3,7},
        new int[]{3,7,10},
        new int[]{2,4},
        new int[]{2}
    };

    private static readonly int[][] peaksS =
    {
        new int[]{6,3},
        new int[]{6,3},
        new int[]{6,3,2},
        new int[]{3,2},
        new int[]{3}
    };

    [Test]
    public void SampleTests()
    {
        for(int n = 0; n < msg.Length; n++)
        {
            int[] p1 = posS[n], p2 = peaksS[n];
            var expected = new Dictionary<string, List<int>>()
            {
                ["pos"] = p1.ToList(),
                ["peaks"] = p2.ToList()
            };
            var actual = PickPeaks.GetPeaks(array[n]);
            Assert.AreEqual(expected, actual, msg[n]);
        }
    }
}
