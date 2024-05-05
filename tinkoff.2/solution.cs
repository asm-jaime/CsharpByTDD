using System.Linq;

namespace tinkoff2;

class TextAnalyzer
{
    public static (int MinLength, int MaxLength) AnalyzeText(string text)
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
