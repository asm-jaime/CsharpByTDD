using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace lngsimpleinteractiveinterpreter;

class Interpreter
{
    private static readonly Dictionary<
        string,
        Func<
            string, string,
            Dictionary<string, double>,
            Dictionary<string, double>,
            Dictionary<string, (List<string>, List<string>)>,
            double?
        >
        > Operations =
        new()
        {
                {"%",(a, b, scope, vars, functions) => GetValue(a, scope, vars) % GetValue(b, scope, vars) },
                {"/",(a, b, scope, vars, functions) => GetValue(a, scope, vars) / GetValue(b, scope, vars) },
                {"*",(a, b, scope, vars, functions) => GetValue(a, scope, vars) * GetValue(b, scope, vars) },
                {"+",(a, b, scope, vars, functions) => GetValue(a, scope, vars) + GetValue(b, scope, vars) },
                {"-",(a, b, scope, vars, functions) => GetValue(a, scope, vars) - GetValue(b, scope, vars) },
                {"=",(a, b, scope, vars, functions) => {
                    var valueB  = GetValue(b, scope, vars);
                    if (double.TryParse(a, out double parsedA))
                    {
                        return null;
                    }
                    else if(valueB.Equals(null))
                    {
                        return null;
                    }
                    else if (functions.ContainsKey(a))
                    {
                        return null;
                    }
                    else if (scope.ContainsKey(a))
                    {
                        scope[a] = (double) valueB;
                    }
                    else
                    {
                        vars[a] = (double) valueB;
                    }
                    return valueB;
                }},
        };

    readonly Dictionary<string, (List<string>, List<string>)> _functions = new();
    readonly Dictionary<string, double> _vars = new();

    private static double? GetValue(string value, Dictionary<string, double> scope, Dictionary<string, double> vars)
    {
        if(double.TryParse(value, out double fromParse))
        {
            return fromParse;
        }
        if(scope.TryGetValue(value, out double fromScope))
        {
            return fromScope;
        }
        if(vars.TryGetValue(value, out double fromVars))
        {
            return fromVars;
        }
        return null;
    }

    private double? Parse(List<string> terms, Dictionary<string, double> scope)
    {
        List<string> termList = new();

        for(int i = 0; i < terms.Count; i++)
        {
            var term = terms[i];
            if(double.TryParse(term, out _))
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
                termList.Add(Parse(innerTerms, scope).ToString());
            }
            else if(term.Equals("fn"))
            {
                i++;
                var funcName = terms[i];
                i++;
                var funcArgs = new List<string>();
                var funcBody = new List<string>();
                for(; i < terms.Count; i++)
                {
                    if(terms[i].Equals("=>")) break;
                    funcArgs.Add(terms[i]);
                }
                i++;
                for(; i < terms.Count; i++)
                {
                    funcBody.Add(terms[i]);
                }
                _functions[funcName] = (funcArgs, funcBody);
            }
            else termList.Add(term);
        }

        ExecuteFunctions(termList, scope, _functions);
        ExecuteOperations(termList, scope, Operations, _functions);

        if(termList.Count > 1) throw new Exception("too many remains");

        double? result = GetValue(termList.LastOrDefault(), scope, _vars);

        if(result.Equals(null)) throw new Exception("bad result in last term");

        return result;
    }
    private void ExecuteFunctions(List<string> termList, Dictionary<string, double> scope, Dictionary<string, (List<string>, List<string>)> functions)
    {
        for(int i = termList.Count - 1; i > -1; --i)
        {
            var term = termList[i];
            if(functions.ContainsKey(term))
            {
                var (funcArgs, funcBody) = functions[term];
                termList.RemoveAt(i);

                var args = new double[funcArgs.Count];
                if(args.Length > termList.Count - i) throw new Exception("wrong argument lenght");
                for(int argId = 0; argId < args.Length; argId++)
                {
                    double? value = GetValue(termList[i], scope, _vars);
                    if(value.Equals(null)) throw new Exception("bad argument valueation");
                    args[argId] = (double)value;
                    termList.RemoveAt(i);
                }

                for(int indexArg = 0; indexArg < funcArgs.Count; indexArg++)
                {
                    scope[funcArgs[indexArg]] = args[indexArg];
                }
                double? result = Parse(funcBody, scope);
                if(result.Equals(null)) throw new Exception("function return null");
                termList.Insert(i, ((double)result).ToString());
            }
        }
    }

    private void ExecuteOperations(List<string> list, Dictionary<string, double> scope, Dictionary<string, Func<string, string, Dictionary<string, double>, Dictionary<string, double>, Dictionary<string, (List<string>, List<string>)>, double?>> operations, Dictionary<string, (List<string>, List<string>)> functions)
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
            var func = operations[list[op]];
            list[op] = func(list[op - 1], list[op + 1], scope, _vars, functions).ToString();
            list.RemoveAt(op + 1);
            list.RemoveAt(op - 1);
        }

    }


    public double? Input(string input)
    {
        List<string> tokens = Tokenize(input);
        tokens.RemoveAt(tokens.Count - 1);

        var globalScope = new Dictionary<string, double>();
        double? result;
        try
        {
            result = Parse(tokens, globalScope);
        }
        catch
        {
            result = null;
        }

        return result;
    }

    private static List<string> Tokenize(string input)
    {
        input += ")";
        List<string> tokens = new();
        Regex rgxMain = new("=>|[-+*/%=\\(\\)]|[A-Za-z_][A-Za-z0-9_]*|[0-9]*(\\.?[0-9]+)");
        MatchCollection matches = rgxMain.Matches(input);
        foreach(Match m in matches.Cast<Match>())
        {
            tokens.Add(m.Groups[0].Value);
        }

        return tokens;
    }
}
