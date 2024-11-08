using System;
using System.Threading.Tasks;

namespace csharpTPLasyncwithoutawait;

class Program
{
    private static string _message;

    static void Main(string[] args)
    {
        //var result = SaySomething();
        SaySomething();

        //Console.WriteLine(result.Result);
        Console.WriteLine(_message);
    }

    static async Task<string> SaySomething()
    {
        await Task.Delay(5);

        _message = "Hello world";

        return "Something";
    }
}