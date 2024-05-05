using System;

namespace csharpavoidfinally;

class Solution
{
    public static bool Calculate()
    {
        bool isFinallyHappened = false;

        try
        {
            // return isFinallyHappened; // this make to return false, but strill, finally will happens
            goto LabelOutside;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString(), isFinallyHappened);
        }
        finally
        {
            isFinallyHappened = true;
            // return isFinallyHappened; // you can't set return inside finally
        }

        LabelOutside:

        return isFinallyHappened;
    }
}
