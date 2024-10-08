using System;

namespace csharpexceptionsequence;

class Solution
{
    internal string GetExceptionSequenceString(bool isThrow)
    {
        var result = string.Empty;

        try
        {
            if(isThrow)
            {
                throw new Exception("throwed, ");
            }
        }
        catch(Exception ex)
        {
            result = $"{result}{ex.Message}";
        }
        finally
        {
            result = $"{result}finally";
        }

        result = $"{result}, and the end";
        return result;
    }
}
