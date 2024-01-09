using System;

namespace tinkoff2;

class Program
{
    static void Main(string[] args)
    {
        string number = Console.ReadLine();
        string text = Console.ReadLine();

        TextAnalyzer analyzer = new TextAnalyzer();
        var (minLength, maxLength) = analyzer.AnalyzeText(text);

        Console.WriteLine($"{minLength} {maxLength}");
    }
}