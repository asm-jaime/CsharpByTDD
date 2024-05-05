using System.Text;

namespace lngesolang1;

class EsolangEasy
{
    private static byte _cell = 0;

    internal static string MyFirstInterpreter(string code)
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
