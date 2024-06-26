﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace numbercombinations;

class Combinator<T>
{
    private readonly T[] _elements;
    private readonly List<T[]> _combinations;
    private readonly int _sizeOfCombo;

    internal Combinator(T[] elements, int sizeOfCombo)
    {
        _elements = elements;
        _sizeOfCombo = sizeOfCombo;

        _combinations = new List<T[]>();
    }

    internal List<T[]> GetCombinations()
    {
        Combine(new T[_sizeOfCombo], 0);
        return _combinations;
    }

    private void Combine(T[] combo, int pos)
    {
        if(pos >= _sizeOfCombo)
        {
            _combinations.Add(combo.Clone() as T[]);
            return;
        }

        foreach(T element in _elements)
        {
            combo[pos] = element;
            Combine(combo, pos + 1);
        }
    }

}

class ProofOfThreeAndFive
{
    internal static bool IsAllRangeCanBeCombinedByNumbers(int first, int second, int[] numbers)
    {
        int count = second - first;

        var summarizedCombinations = (
                from num1 in numbers
                from num2 in numbers
                select new List<int> { num1, num2 }
            ).Concat(
                from num1 in numbers
                from num2 in numbers
                from num3 in numbers
                select new List<int> { num1, num2, num3 }
            ).Concat(
                from num1 in numbers
                from num2 in numbers
                from num3 in numbers
                from num4 in numbers
                select new List<int> { num1, num2, num3, num4 }
            ).Concat(
                from num1 in numbers
                from num2 in numbers
                from num3 in numbers
                from num4 in numbers
                from num5 in numbers
                select new List<int> { num1, num2, num3, num4, num5 }
            ).Select(nums => nums.Sum()).ToHashSet();

        return Enumerable
            .Range(first, count)
            .Where(number => summarizedCombinations.Contains(number).Equals(true))
            .Count().Equals(count);
    }
}
