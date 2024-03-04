using System;

namespace tinkoff2;

class Program
{
    static void Main(string[] _)
    {
        Console.ReadLine();
        string text = Console.ReadLine();

        var (minLength, maxLength) = TextAnalyzer.AnalyzeText(text);

        Console.WriteLine($"{minLength} {maxLength}");
    }
}