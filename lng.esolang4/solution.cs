using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lngesolang4;

public static class ByteHelper
{
    public static byte Reverse(this byte bits)
    {
        int result = 0;
        for(int bitIndex = 0; bitIndex < 8; bitIndex++)
        {
            if((bits & (1 << bitIndex)) != 0)
            {
                result |= 1 << (7 - bitIndex);
            }
        }
        return (byte)result;
    }

    public static byte[] BitArrayToByteArray(this BitArray bits)
    {
        //var remain = bits.Length % 8 > 0 ? 1 : 0;
        var remain = 1;
        byte[] ret = new byte[(bits.Length - 1) / 8 + remain];
        bits.CopyTo(ret, 0);
        return ret;
    }
}

class Boolfuck
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

    private static string OutputBitStreamToString(List<bool> outputStream)
    {
        if(outputStream.Count.Equals(0)) return "";

        var paddedZeros = Enumerable.Range(0, (outputStream.Count % 8)).Select(zero => false).ToList();
        outputStream.AddRange(paddedZeros);
        var bitArray = new BitArray(outputStream.Count);
        for(int indexBit = 0; indexBit < outputStream.Count; ++indexBit)
        {
            bitArray[indexBit] = outputStream[indexBit];
        }
        return bitArray
            .BitArrayToByteArray()
            .Select(oneByte => BitConverter.ToChar(new byte[2] { oneByte, new byte() }).ToString())
            .Aggregate((acc, ch) => $"{acc}{ch}");
    }

    public static string Interpret(string code, string input)
    {
        var programIndex = 0;
        var instructionIndex = 0;

        var outputStream = new List<bool>();
        var inputStream = new List<bool>();
        {
            var inputBits = new BitArray(
                input
                    .Select(ch => BitConverter.GetBytes(ch).FirstOrDefault(new byte()))
                    .ToArray()
            );
            foreach(var bit in inputBits) inputStream.Add((bool)bit);
        }
        var memory = new List<bool>();
        var bracketPairAdress = GetBracketAdressMap(code);

        while(instructionIndex > -1 && instructionIndex < code.Length)
        {
            var instruction = code[instructionIndex];

            if(programIndex >= memory.Count) memory.Add(false);
            if(programIndex < 0)
            {
                memory.Insert(0, false);
                programIndex = 0;
            }

            //if (programIndex < 0 || programIndex > memory.Length - 1) break;

            if(instruction.Equals('+'))
            {
                memory[programIndex] = !memory[programIndex];
            }
            else if(instruction.Equals(','))
            {
                var inputData = inputStream.FirstOrDefault(false);
                inputStream.Remove(inputData);

                memory[programIndex] = inputData;
            }
            else if(instruction.Equals(';'))
            {
                outputStream.Add(memory[programIndex]);
            }
            else if(instruction.Equals('>'))
            {
                programIndex++;

            }
            else if(instruction.Equals('<'))
            {
                programIndex--;
            }
            else if(instruction.Equals('[') && memory[programIndex].Equals(false))
            {
                instructionIndex = bracketPairAdress[instructionIndex];
                continue;
            }
            else if(instruction.Equals(']') && memory[programIndex].Equals(true))
            {
                instructionIndex = bracketPairAdress[instructionIndex];
                continue;
            }

            instructionIndex++;
        }

        return OutputBitStreamToString(outputStream);
    }
}
