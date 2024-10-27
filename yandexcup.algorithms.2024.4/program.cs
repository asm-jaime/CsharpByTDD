using System;

namespace yandexcupalgorithms20244
{
    class Program
    {
        static void Main(string[] args)
        {
            for(long h = 1; h <= 200; h++)
            {
                Console.WriteLine(h);
                Console.Out.Flush();

                string response = Console.ReadLine();
                if(response == "ok")
                {
                    Console.WriteLine("! " + h);
                    Console.Out.Flush();
                    return;
                }
                else if(response == "fail")
                {
                    return;
                }
                // Если ответ "wet", продолжаем.
            }
        }
    }
}
