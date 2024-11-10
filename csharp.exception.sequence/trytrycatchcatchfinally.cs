using System;

namespace csharpexceptionsequence;

class E1 : Exception
{
    public E1() : base(message: typeof(E1).Name) { }
};
class E2 : Exception
{
    public E2() : base(message: typeof(E2).Name) { }
};
class E3 : Exception
{
    public E3() : base(message: typeof(E3).Name) { }
};

class TryTryCatchCatchFinally
{
    internal string GetExceptionSequenceString()
    {
        var result = string.Empty;

        try
        {
            try
            {
                throw new E1();
            }
            catch
            {
                throw new E2();
            }
            finally
            {
                throw new E3();
            }
        }
        catch(Exception ex)
        {
            result = ex.Message;
        }

        return result;
    }
}
