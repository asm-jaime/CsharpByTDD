using System;
using System.Text;

namespace encryption;

class Encryption
{
    private static string Mix(string text)
    {
        StringBuilder left = new();
        StringBuilder right = new();
        for(int i = 0; i < text.Length; ++i)
        {
            if(i % 2 == 0)
            {
                right.Append(text[i]);
            }
            else
            {
                left.Append(text[i]);
            }
        }
        return $"{left}{right}";
    }

    private static string Unmix(string cryptedText)
    {
        int length = cryptedText.Length / 2;

        string left = cryptedText[..length];
        string right = cryptedText[length..];
        StringBuilder result = new();
        for(int i = 0; i < right.Length; ++i)
        {
            result.Append(right[i]);
            if(i == left.Length) continue;
            result.Append(left[i]);
        }

        return result.ToString();
    }

    private static string RepeatFunction(Func<string, string> repeatFunc, string text, int time)
    {
        var currentText = text;
        for(int i = 0; i < time; ++i)
        {
            currentText = repeatFunc(currentText);
        }

        return currentText;

    }

    public static string Encrypt(string text, int n)
    {
        return RepeatFunction(Mix, text, n);
    }

    public static string Decrypt(string text, int n)
    {
        return RepeatFunction(Unmix, text, n);
    }
}
