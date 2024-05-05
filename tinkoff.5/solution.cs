using System.Collections.Generic;
using System.Linq;

namespace tinkoff5;

class Solution
{
    internal static int DeliverPackage(string[] inputData)
    {
        var header = inputData[0].Split();
        int n = int.Parse(header[0]), m = int.Parse(header[1]), k = int.Parse(header[2]);

        var routes = new Dictionary<(int, int), int>();
        for(int i = 1; i <= m; i++)
        {
            var parts = inputData[i].Split();
            int u = int.Parse(parts[0]), v = int.Parse(parts[2]), d = int.Parse(parts[1]);
            routes.Add((u, d), v);
        }

        var path = inputData[m + 1].Split().Select(int.Parse).ToArray();
        int currentPoint = 1;

        foreach(var vehicle in path)
        {
            if(!routes.TryGetValue((currentPoint, vehicle), out currentPoint))
            {
                return 0;
            }
        }

        return currentPoint;
    }
}

