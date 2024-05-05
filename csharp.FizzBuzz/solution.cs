using System;

namespace csharpFizzBuzz;

public class Solution
{
    public void PrintFizzBuzz(int num)
    {
        for(var i = 1; i <= num; i++)
        {
            if(i % 3 is 0 && i % 5 is 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if(i % 3 is 0)
            {
                Console.WriteLine("Fizz");
            }
            else if(i % 5 is 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }

    public void PrintFizzBuzzWithUseOneOutput(int num)
    {
        for(var i = 1; i <= num; i++)
        {
            var result = string.Empty;

            if(i % 3 is 0)
            {
                result = "Fizz";
            }
            if(i % 5 is 0)
            {
                result = $"{result}Buzz";
            }

            if(string.IsNullOrEmpty(result))
            {
                result = i.ToString();
            }

            Console.WriteLine(result);
        }
    }
}