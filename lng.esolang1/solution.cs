using System.Text;

namespace lngesolang1;

public class EsolangEasy
{
    private static byte _cell = 0;

    public static string MyFirstInterpreter(string code)
    {
        _cell = 0;
        StringBuilder result = new();
        foreach(var letter in code)
        {
            if(letter.Equals('+')) _cell++;
            if(letter.Equals('.'))
            {
                result.Append((char)_cell);
            }
        }

        return result.ToString();
    }
}
