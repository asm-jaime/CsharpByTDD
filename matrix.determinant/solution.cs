using System;
using System.Collections.Generic;

namespace matrixdeterminant;

internal struct Minor
{
    internal int Element { get; set; }
    internal int[][] Matrix { get; set; }
}

interface IDeterminant
{
    internal static int[][] GetMinorElement(int[][] matrix, int excludeRow, int excludeColumn)
    {
        var result = new List<int[]>();
        for(int row = 0; row < matrix.Length; ++row)
        {
            if(row == excludeRow) continue;

            var currentRow = new List<int>();
            for(int column = 0; column < matrix.Length; ++column)
            {
                if(column == excludeColumn) continue;

                currentRow.Add(matrix[row][column]);
            }
            result.Add(currentRow.ToArray());
        }

        return result.ToArray();
    }

    int Solve();
}

class QueueDeterminant : IDeterminant
{
    private readonly int[][] _matrix;

    internal QueueDeterminant(int[][] mainMatrix)
    {
        _matrix = mainMatrix;
    }

    public int Solve()
    {
        int result = 0;

        Queue<Minor> minors = new();
        minors.Enqueue(new Minor { Element = 1, Matrix = _matrix });

        while(minors.Count > 0)
        {
            var minor = minors.Dequeue();
            var matrix = minor.Matrix;

            if(matrix.Length == 1)
            {
                result += matrix[0][0];
                continue;
            }
            if(matrix.Length == 2)
            {
                result += minor.Element * (matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0]);
                continue;
            }

            int row = 0;
            for(int column = 0; column < matrix.Length; ++column)
            {
                minors.Enqueue(new Minor
                {
                    Element = (int)Math.Pow(-1, row + column) * minor.Element * matrix[row][column],
                    Matrix = IDeterminant.GetMinorElement(matrix, row, column)
                });
            }
        }

        return result;
    }
}

class RecursiveDeterminant : IDeterminant
{
    private int _det = 0;
    private readonly int[][] _matrix;

    internal RecursiveDeterminant(int[][] mainMatrix)
    {
        _matrix = mainMatrix;
    }

    public void SolveMatrix(int[][] matrix, int element)
    {
        if(element == 0) return;

        if(matrix.Length == 1)
        {
            _det += matrix[0][0]; return;
        }

        if(matrix.Length == 2)
        {
            _det += element * (matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0]);
            return;
        }

        int row = 0;
        for(int column = 0; column < matrix.Length; ++column)
        {
            SolveMatrix(
                IDeterminant.GetMinorElement(matrix, row, column),
                (int)Math.Pow(-1, row + column) * element * matrix[row][column]
            );
        }
    }
    public int Solve()
    {
        SolveMatrix(_matrix, 1);
        return _det;
    }
}


class Matrix
{
    internal static int Determinant(int[][] matrix)
    {
        IDeterminant determinant = new RecursiveDeterminant(matrix);
        var result = determinant.Solve();
        return result;
    }

}
