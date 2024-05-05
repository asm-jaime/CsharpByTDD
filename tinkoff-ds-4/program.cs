using System;

namespace tinkoffds4;


class Solution
{
    internal static int CalculateScans(int L, int[] particleCoords)
    {
        int scans = 0;
        int currentEnd = particleCoords[0] + L;

        foreach (var coord in particleCoords)
        {
            if (coord > currentEnd)
            {
                scans++;
                currentEnd = coord + L;
            }
        }

        return scans + 1;
    }
}

class Program
{
    static void Main(string[] _)
    {
        string[] firstLine = Console.ReadLine().Split();
        int n = int.Parse(firstLine[0]);
        int L = int.Parse(firstLine[1]);

        string[] particlesLine = Console.ReadLine().Split();
        int[] particleCoords = new int[n];
        for (int i = 0; i < n; i++)
        {
            particleCoords[i] = int.Parse(particlesLine[i]);
        }

        int totalScans = Solution.CalculateScans(L, particleCoords);

        Console.WriteLine(totalScans);
    }
}
