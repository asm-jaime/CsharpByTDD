using System;
using System.Collections.Generic;

namespace lngmathdifferentiation;

    class PrefixDiff
    {
        //calc(op, a, b):
        private static Dictionary<string, Func<double, double, double>> Operations =
            new Dictionary<string, Func<double, double, double>>()
            {
                {"^", (a, b) => Math.Pow(a, b) },
                {"*", (a, b) => a * b },
                {"/", (a, b) => a / b },
                {"+", (a, b) => a + b },
                {"-", (a, b) => a - b },
            };

        private string Parse(string str)
        {
            return "";
        }

        public string Diff(string expr)
        {
            // Method required

            return "";
        }
    }
