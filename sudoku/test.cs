﻿using NUnit.Framework;

namespace sudoku;

class SudokuTestCaseBuilder
{
    private bool _expectedResult;
    private int[][] _board;

    public SudokuTestCaseBuilder WithExpectedResult(bool expectedResult)
    {
        _expectedResult = expectedResult;
        return this;
    }

    public SudokuTestCaseBuilder WithBoard(int[][] board)
    {
        _board = board;
        return this;
    }

    public void BuildAndTest()
    {
        Assert.AreEqual(_expectedResult, Sudoku.ValidateSudoku(_board));
    }
}

[TestFixture]
class Sample_Tests
{
    [Test]
    public void TestCase1()
    {
        new SudokuTestCaseBuilder()
            .WithExpectedResult(true)
            .WithBoard(new int[][]
            {
                new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
                new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
                new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9},
            })
            .BuildAndTest();
    }

    [Test]
    public void TestCase2()
    {
        new SudokuTestCaseBuilder()
            .WithExpectedResult(false)
            .WithBoard(new int[][]
            {
                new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                new int[] {1, 9, 8, 3, 0, 2, 5, 6, 7},
                new int[] {8, 5, 0, 7, 6, 1, 4, 2, 3},
                new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                new int[] {7, 0, 3, 9, 2, 4, 8, 5, 6},
                new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                new int[] {3, 0, 0, 2, 8, 6, 1, 7, 9},
            })
            .BuildAndTest();
    }
}

