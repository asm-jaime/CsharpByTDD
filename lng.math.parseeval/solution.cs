using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace lngmathparseeval;

internal static class BracketChecker
{
    private const int BracketHasNoPair = -1;

    private static Dictionary<int, int> GetBracketAdressMap(string code)
    {
        var result = new Dictionary<int, int>();
        var brackets = new Stack<int>();
        for(var index = 0; index < code.Length; ++index)
        {
            var letter = code[index];
            if(letter.Equals('('))
            {
                result[index] = BracketHasNoPair;
                brackets.Push(index);
            }
            else if(letter.Equals(')'))
            {
                result[index] = BracketHasNoPair;

                var isSuccess = brackets.TryPop(out var bracketIndex).Equals(true);
                if(isSuccess)
                {
                    result[bracketIndex] = index;
                    result[index] = bracketIndex;
                }
            }
        }
        return result;
    }
    internal static bool IsBracketsBad(string code)
    {
        return GetBracketAdressMap(code).Values.Any(e => e.Equals(-1));
    }
}

class Evaluate
{
    private static readonly Dictionary<string, Func<double, double, double>> OperationsA =
        new()
        {
                {"sqrt", (a, b) => Math.Sqrt(a)  },
                {"log" , (a, b) => Math.Log10(a) },
                {"ln"  , (a, b) => Math.Log(a)   },
                {"exp" , (a, b) => Math.Exp(a)   },
                {"abs" , (a, b) => Math.Abs(a)   },
                {"atan", (a, b) => Math.Atan(a)  },
                {"acos", (a, b) => Math.Acos(a)  },
                {"asin", (a, b) => Math.Asin(a)  },
                {"sinh", (a, b) => Math.Sinh(a)  },
                {"cosh", (a, b) => Math.Cosh(a)  },
                {"tanh", (a, b) => Math.Tanh(a)  },
                {"tan" , (a, b) => Math.Tan(a)   },
                {"sin" , (a, b) => Math.Sin(a)   },
                {"cos" , (a, b) => Math.Cos(a)   },
        };
    private static readonly Dictionary<string, Func<double, double, double>> OperationsB =
        new()
        {
                {"&"   , (a, b) => Math.Pow(a, b)},
        };
    private static readonly Dictionary<string, Func<double, double, double>> OperationsC =
        new()
        {
                {"-"   , (a, b) => -a },
        };
    private static readonly Dictionary<string, Func<double, double, double>> OperationsD =
        new()
        {
                {"*"   , (a, b) => a * b },
                {"/"   , (a, b) => a / b },
                {"+"   , (a, b) => a + b },
        };

    private double Parse(List<string> terms)
    {

        List<string> termList = new();

        for(int i = 0; i < terms.Count; i++)
        {
            var term = terms[i];
            if(double.TryParse(term.Replace(".", ","), out _))
            {
                termList.Add(term);
            }
            else if(term.Equals("("))
            {
                var innerTerms = new List<string>();
                i++;
                int bracketCount = 0;
                for(; i < terms.Count; i++)
                {
                    term = terms[i];
                    if(term.Equals("(")) bracketCount++;
                    if(term.Equals(")") && bracketCount.Equals(0)) break;
                    if(term.Equals(")") && bracketCount > 0) --bracketCount;

                    innerTerms.Add(term);
                }
                termList.Add(Parse(innerTerms).ToString());
            }
            else if(term.Equals("+")) termList.Add(term);
            else if(term.Equals("&")) termList.Add(term);
            else if(term.Equals("-")) termList.Add(term);
            else if(term.Equals("*")) termList.Add(term);
            else if(term.Equals("/")) termList.Add(term);
            else if(term.Equals("sqrt")) termList.Add(term);
            else if(term.Equals("log")) termList.Add(term);
            else if(term.Equals("ln")) termList.Add(term);
            else if(term.Equals("exp")) termList.Add(term);
            else if(term.Equals("abs")) termList.Add(term);
            else if(term.Equals("atan")) termList.Add(term);
            else if(term.Equals("acos")) termList.Add(term);
            else if(term.Equals("asin")) termList.Add(term);
            else if(term.Equals("sinh")) termList.Add(term);
            else if(term.Equals("cosh")) termList.Add(term);
            else if(term.Equals("tanh")) termList.Add(term);
            else if(term.Equals("tan")) termList.Add(term);
            else if(term.Equals("sin")) termList.Add(term);
            else if(term.Equals("cos")) termList.Add(term);
        }

        ExecuteUnary(termList, OperationsA);
        ExecuteBinary(termList, OperationsB);
        ExecuteUnary(termList, OperationsC);
        ExecuteBinary(termList, OperationsD);
        return double.Parse(termList.LastOrDefault());
    }

    private static void ExecuteUnary(List<string> list, Dictionary<string, Func<double, double, double>> operations)
    {
        for(int i = 0; i < list.Count; ++i)
        {
            if(operations.TryGetValue(list[i], out var func))
            {
                list[i] = func(double.Parse(list[i + 1]), 1).ToString();
                list.RemoveAt(i + 1);
            }
        }
    }

    private static void ExecuteBinary(List<string> list, Dictionary<string, Func<double, double, double>> operations)
    {
        var prioritizedOperations = operations.Keys.ToArray();
        var prioritizedIndex = 0;
        while(list.Count > 1 && prioritizedIndex < prioritizedOperations.Length)
        {
            var op = list.FindLastIndex(e => e.Equals(prioritizedOperations[prioritizedIndex]));
            if(op < 0)
            {
                prioritizedIndex++;
                continue;
            }
            double right = double.Parse(list[op + 1].Replace(",", "."));
            var func = operations[list[op]];
            double left = double.Parse(list[op - 1].Replace(",", "."));
            list[op] = func(left, right).ToString();
            list.RemoveAt(op + 1);
            list.RemoveAt(op - 1);
        }
    }

    private static readonly Regex UnnecessaryWhitespaces;
    private static readonly Regex UnnecessaryPlus;
    private static readonly Regex RestrictedMinusPlus;
    private static readonly Regex NamesSplit;
    private static readonly Regex Terms;

    internal static Dictionary<string, Func<double, double, double>> OperationsD1 => OperationsD;

    private static List<string> RemoveMinusFromBynaryExpression(List<string> terms)
    {
        for(var i = 2; i < terms.Count; ++i)
        {
            if(
                double.TryParse(terms[i], out double currentP) &&
                terms[i - 1][0].Equals('-') &&
                terms[i - 2].Equals("+")
               )
            {
                if(terms[i - 1].Length % 2 == 0)
                {
                    terms.RemoveAt(i - 1);
                }
                else
                {
                    terms.RemoveAt(i - 1);
                    terms[i] = (-currentP).ToString();
                }
            }

            if(
                double.TryParse(terms[i], out double current) &&
                terms[i - 1][0].Equals('-') &&
                (double.TryParse(terms[i - 2], out _) || terms[i - 2].Equals(")"))
               )
            {
                if(terms[i - 1].Length % 2 == 0)
                {
                    terms[i - 1] = "+";
                }
                else
                {
                    terms[i - 1] = "+";
                    terms[i] = (-current).ToString();
                }
            }

        }
        return terms;
    }

    internal string Eval(string expression)
    {
        var stageString = expression.ToLower();
        if(NamesSplit.IsMatch(stageString)) return "error";
        stageString = UnnecessaryWhitespaces.Replace(stageString, "");
        if(BracketChecker.IsBracketsBad(expression)) return "error";
        stageString = UnnecessaryPlus.Replace(stageString, "-$1");
        if(RestrictedMinusPlus.IsMatch(stageString)) return "error";

        var stageList = Terms.Matches(stageString).Select(match => match.Value).ToList();
        stageList = RemoveMinusFromBynaryExpression(stageList);
        var result = Parse(stageList);

        if(double.IsNaN(result) || double.IsInfinity(result))
        {
            return "error";
        }

        return result.ToString();
    }
}
