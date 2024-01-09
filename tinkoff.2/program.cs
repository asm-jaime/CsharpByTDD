using System;
using System.Linq;

public class TextAnalyzer
{
    public (int MinLength, int MaxLength) AnalyzeText(string text)
    {
        var lines = text.Split('#');
        if (lines.Length == 0)
            return (0, 0);

        var minLength = lines.Min(line => line.Length);
        var maxLength = lines.Max(line => line.Length);

        // Handling the case where the text ends with '#', which creates an empty line
        if (text.EndsWith("#") && minLength == 0)
        {
            minLength = 0;
        }

        return (minLength, maxLength);
    }
}


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