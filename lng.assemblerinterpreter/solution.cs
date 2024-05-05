using System.Collections.Generic;
using System.Text;

namespace lngassemblerinterpreter;

class Executor
{
    private readonly Dictionary<string, int> _state = new();
    private readonly Dictionary<string, int> _labels = new();
    private readonly Stack<int> _callstack = new();
    private readonly string[] _program = System.Array.Empty<string>();

    private bool _processing = true;
    private bool _isCmpEquals = false;
    private bool _isCmpFirstLessThanSecond = false;
    private int _executionIndex = 0;

    private bool _executionError = false;

    private readonly StringBuilder _result = new();

    private int GetValue(string operand)
    {
        if(_state.TryGetValue(operand, out int value).Equals(false))
        {
            value = int.Parse(operand);
        }
        return value;
    }

    private static (string[], Dictionary<string, int>) ParseText(string programText)
    {
        var program = new List<string>();
        var labels = new Dictionary<string, int>();

        var lines = programText.Split("\n");
        foreach(var line in lines)
        {
            var formatLine = line.Trim().Split(';')[0];
            if(string.IsNullOrWhiteSpace(formatLine)) continue;


            var labelParts = formatLine.Split(':');
            if(labelParts.Length > 1 && labelParts[1] == "")
            {
                labels[labelParts[0]] = program.Count;
                continue;
            }

            program.Add(formatLine);
        }

        return (program.ToArray(), labels);
    }

    internal Executor(string programText)
    {
        (_program, _labels) = ParseText(programText);
    }

    private static string[] GetArguments(string line)
    {
        var result = new List<string>();

        if(string.IsNullOrEmpty(line)) return result.ToArray();

        var buff = new StringBuilder();
        bool stringFlag = false;
        foreach(var letter in line)
        {
            if(stringFlag)
            {
                buff.Append(letter);
                if(letter == '\'') stringFlag = false;
                continue;
            }
            if(letter == '\'')
            {
                buff.Append(letter);
                stringFlag = true;
                continue;
            }
            if(letter == ',')
            {
                result.Add(buff.ToString().Trim());
                buff.Clear();
                continue;
            }
            buff.Append(letter);
        }
        result.Add(buff.ToString().Trim());

        return result.ToArray();
    }

    private static (string, string[]) ParseInstruction(string programLine)
    {
        var firstWordIndex = programLine.IndexOf(' ');
        if(firstWordIndex < 0)
        {
            return (programLine, null);
        }
        var wordLength = firstWordIndex;
        var instruction = programLine[..wordLength];
        var arguments = GetArguments(programLine[wordLength..]);

        return (instruction, arguments);
    }

    private void Execute(string programLine)
    {
        var (instructionName, arguments) = ParseInstruction(programLine);
        switch(instructionName)
        {
            case "mov":
                _state[arguments[0]] = GetValue(arguments[1]);
                _executionIndex++; break;
            case "inc":
                _state[arguments[0]]++;
                _executionIndex++; break;
            case "dec":
                _state[arguments[0]]--;
                _executionIndex++; break;
            case "add":
                _state[arguments[0]] += GetValue(arguments[1]);
                _executionIndex++; break;
            case "sub":
                _state[arguments[0]] -= GetValue(arguments[1]);
                _executionIndex++; break;
            case "mul":
                _state[arguments[0]] *= GetValue(arguments[1]);
                _executionIndex++; break;
            case "div":
                _state[arguments[0]] /= GetValue(arguments[1]);
                _executionIndex++; break;
            case "cmp":
                var first = GetValue(arguments[0]);
                var second = GetValue(arguments[1]);
                _isCmpEquals = first == second;
                _isCmpFirstLessThanSecond = first < second;
                _executionIndex++; break;
            case "msg":
                foreach(var argument in arguments)
                {
                    var messageParts = argument.Split('\'');
                    if(messageParts.Length > 1)
                    {
                        _result.Append(messageParts[1]);
                    }
                    else
                    {
                        _result.Append(GetValue(argument));
                    }
                }
                _executionIndex++; break;
            case "jmp":
                _executionIndex = _labels[arguments[0]];
                break;
            case "jne":
                if(_isCmpEquals.Equals(false))
                {
                    _executionIndex = _labels[arguments[0]];
                }
                else
                {
                    _executionIndex++;
                }
                break;
            case "je":
                if(_isCmpEquals)
                {
                    _executionIndex = _labels[arguments[0]];
                }
                else
                {
                    _executionIndex++;
                }
                break;
            case "jge":
                if(_isCmpFirstLessThanSecond.Equals(false) || _isCmpEquals.Equals(true))
                {
                    _executionIndex = _labels[arguments[0]];
                }
                else
                {
                    _executionIndex++;
                }
                break;
            case "jg":
                if(_isCmpFirstLessThanSecond.Equals(false) && _isCmpEquals.Equals(false))
                {
                    _executionIndex = _labels[arguments[0]];
                }
                else
                {
                    _executionIndex++;
                }
                break;
            case "jle":
                if(_isCmpFirstLessThanSecond || _isCmpEquals)
                {
                    _executionIndex = _labels[arguments[0]];
                }
                else
                {
                    _executionIndex++;
                }
                break;
            case "jl":
                if(_isCmpFirstLessThanSecond && _isCmpEquals.Equals(false))
                {
                    _executionIndex = _labels[arguments[0]];
                }
                else
                {
                    _executionIndex++;
                }
                break;
            case "call":
                _callstack.Push(_executionIndex);
                _executionIndex = _labels[arguments[0]];
                break;
            case "ret":
                if(_callstack.Count.Equals(0))
                {
                    _executionError = true;
                    return;
                }
                _executionIndex = _callstack.Pop();
                _executionIndex++;
                break;
            case "end":
                _processing = false; break;
            default:
                break;
        }
    }

    internal string Interprete()
    {
        while(_processing)
        {
            if(_executionIndex >= _program.Length) break;
            if(_executionError) break;
            Execute(_program[_executionIndex]);
        }

        if(_processing) return null;

        return _result.ToString();
    }

}

internal static class AssemblerInterpreter
{
    internal static string Interpret(string programText)
    {
        var executor = new Executor(programText);
        return executor.Interprete();
    }
}
