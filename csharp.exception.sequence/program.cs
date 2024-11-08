using System;

namespace csharpexceptionsequence;


class MyCustomException : DivideByZeroException
{
}

class Program
{

    static void Main(string[] args)
    {
        try
        {
            Calc();
        }
        catch(DivideByZeroException e) when(e is MyCustomException)
        {
            Console.WriteLine("3");
            throw;
        }
        catch(MyCustomException e)
        {
            Console.WriteLine("4");
            throw;
        }
        Console.ReadLine();
    }

    private static void Calc()
    {
        int result = 0;
        var x = 5;
        int y = 0;
        try
        {
            result = x / y;
        }
        catch(MyCustomException e)
        {
            Console.WriteLine("1");
            throw;
        }
        catch(Exception e)
        {
            Console.WriteLine("2");
        }
        finally
        {
            throw new MyCustomException();
        }
    }

}