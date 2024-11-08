using NUnit.Framework.Constraints;
using System;
using System.Threading.Tasks;

namespace csharpTPLasyncwithoutawait;

class Solution
{
}
class Program
{
    private static string _str;

    static async void Calculate()
    {
        await Task.Delay(5);
        _str = "Hello world";
    }
    static void Main(string[] args)
    {
        Calculate();

        Console.WriteLine(_str);
    }
}