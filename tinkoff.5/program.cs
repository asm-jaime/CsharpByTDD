using System.Collections.Generic;
using System;

namespace tinkoff5;

class Program
{
    static void Main(string[] _)
    {
        var numbers = Console.ReadLine();
        var inputData = new List<string>() { numbers };

        int linesCount = int.Parse(numbers.Split()[1]) + 1;

        for (int i = 0; i < linesCount; i++)
        {
            inputData.Add(Console.ReadLine());
        }

        int finalPoint = Solution.DeliverPackage(inputData.ToArray());

        Console.WriteLine(finalPoint);
    }
}