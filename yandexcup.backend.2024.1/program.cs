using System;
using System.Collections.Generic;
using System.Globalization;

namespace yandexcupbackend20241
{
    class Program
    {
        static void Main(string[] args)
        {
            var patients = new Dictionary<int, double>();
            double totalSum = 0.0;
            int patientCount = 0;

            while(true)
            {
                var line = Console.ReadLine();
                if(line == null) break;

                line = line.Trim();

                if(line == "!")
                {
                    break;
                }

                if(line.StartsWith("+"))
                {
                    var tokens = line.Split();
                    int id = int.Parse(tokens[1]);
                    double t = double.Parse(tokens[2], CultureInfo.InvariantCulture);

                    if(!patients.ContainsKey(id))
                    {
                        patients[id] = t;
                        totalSum += t;
                        patientCount += 1;
                    }
                    else
                    {
                        // Если пациент с таким id уже существует, игнорируем или обновляем по необходимости
                        // В условии не указано, что делать в этом случае
                    }
                }
                else if(line.StartsWith("~"))
                {
                    var tokens = line.Split();
                    int id = int.Parse(tokens[1]);
                    double t = double.Parse(tokens[2], CultureInfo.InvariantCulture);

                    if(patients.ContainsKey(id))
                    {
                        double oldTemp = patients[id];
                        totalSum -= oldTemp;
                        patients[id] = t;
                        totalSum += t;
                    }
                    else
                    {
                        // В условии предполагается, что id всегда корректен
                    }
                }
                else if(line.StartsWith("-"))
                {
                    var tokens = line.Split();
                    int id = int.Parse(tokens[1]);

                    if(patients.ContainsKey(id))
                    {
                        double t = patients[id];
                        totalSum -= t;
                        patients.Remove(id);
                        patientCount -= 1;
                    }
                    else
                    {
                        // В условии предполагается, что id всегда корректен
                    }
                }
                else if(line.StartsWith("?"))
                {
                    if(patientCount > 0)
                    {
                        double average = totalSum / patientCount;
                        Console.WriteLine(average.ToString("F9", CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        Console.WriteLine("0.000000000");
                    }
                    Console.Out.Flush();
                }
            }
        }
    }
}
