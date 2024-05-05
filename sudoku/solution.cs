using System.Linq;

namespace sudoku;

class Sudoku
{
    public static bool ValidateSudoku(int[][] board)
    {
        static bool ValidateSubMatrix(int[][] matrix, int col, int row)
        {
            var result = matrix[col + 0].Skip(row).Take(3);
            result = result.Concat(matrix[col + 1].Skip(row).Take(3));
            result = result.Concat(matrix[col + 2].Skip(row).Take(3));

            return result.Sum().Equals(45);
        }

        for(int i = 0; i < board.Length; i += 3)
        {
            for(int j = 0; j < board[i].Length; j += 3)
            {
                if(ValidateSubMatrix(board, i, j).Equals(false)) return false;
            }
        }

        return true;
    }
}
