using System.Collections.Generic;
using System.Linq;

namespace lngesolang2;

class Smallfuck
{
    private const int BracketHasNoPair = -1;
    private static Dictionary<int, int> GetBracketAdressMap(string code)
    {
        var result = new Dictionary<int, int>();
        var brackets = new Stack<int>();
        for(var index = 0; index < code.Length; ++index)
        {
            var letter = code[index];
            if(letter.Equals('['))
            {
                result[index] = BracketHasNoPair;
                brackets.Push(index);
            }
            else if(letter.Equals(']'))
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

    internal static string Interpreter(string code, string tape)
    {
        var porgramIndex = 0;
        var instructionIndex = 0;

        var memory = tape.Select(cell => int.Parse($"{cell}")).ToArray();
        var bracketPairAdress = GetBracketAdressMap(code);

        while(instructionIndex > -1 && instructionIndex < code.Length)
        {
            var instruction = code[instructionIndex];

            if(porgramIndex < 0 || porgramIndex > memory.Length - 1) break;
            if(instruction.Equals('>'))
            {
                porgramIndex++;
            }
            else if(instruction.Equals('<'))
            {
                porgramIndex--;
            }
            else if(instruction.Equals('*'))
            {
                memory[porgramIndex] = (memory[porgramIndex] + 1) % 2;
            }
            else if(instruction.Equals('[') && memory[porgramIndex].Equals(0))
            {
                instructionIndex = bracketPairAdress[instructionIndex];
                continue;
            }
            else if(instruction.Equals(']') && memory[porgramIndex].Equals(0).Equals(false))
            {
                instructionIndex = bracketPairAdress[instructionIndex];
                continue;
            }

            instructionIndex++;
        }

        return memory.Select(cell => $"{cell}").Aggregate((first, second) => $"{first}{second}");
    }
}
