using System.Collections.Generic;
using System.Linq;

namespace gametictactoe3d;

class Dinglemouse
{
    private const int PlayerO = 1;
    private const int PlayerX = 2;
    private static bool CheckPlayer(int player, params int[] cell) =>
        cell.Select(element => element.Equals(player)).Aggregate((acc, element) => acc && element);

    private static bool IsPlayerWon(int[][][] board, int player)
    {
        // line
        for(int y = 0; y < board.Length; y++)
        {
            for(int x = 0; x < board[y].Length; x++)
            {
                if(CheckPlayer(player, board[y][x][0], board[y][x][1], board[y][x][2], board[y][x][3])) return true;
                if(CheckPlayer(player, board[y][0][x], board[y][1][x], board[y][2][x], board[y][3][x])) return true;
                if(CheckPlayer(player, board[0][y][x], board[1][y][x], board[2][y][x], board[3][y][x])) return true;
            }
        }
        //cross
        for(int z = 0; z < board.Length; z++)
        {
            if(CheckPlayer(player, board[z][0][0], board[z][1][1], board[z][2][2], board[z][3][3])) return true;
            if(CheckPlayer(player, board[z][3][0], board[z][2][1], board[z][1][2], board[z][0][3])) return true;
            if(CheckPlayer(player, board[0][z][0], board[1][z][1], board[2][z][2], board[3][z][3])) return true;
            if(CheckPlayer(player, board[3][z][0], board[2][z][1], board[1][z][2], board[0][z][3])) return true;
            if(CheckPlayer(player, board[0][0][z], board[1][1][z], board[2][2][z], board[3][3][z])) return true;
            if(CheckPlayer(player, board[0][3][z], board[1][2][z], board[2][1][z], board[3][0][z])) return true;
        }
        if(CheckPlayer(player, board[0][0][0], board[1][1][1], board[2][2][2], board[3][3][3])) return true;
        if(CheckPlayer(player, board[0][0][3], board[1][1][2], board[2][2][1], board[3][3][0])) return true;
        if(CheckPlayer(player, board[0][3][0], board[1][2][1], board[2][1][2], board[3][0][3])) return true;
        if(CheckPlayer(player, board[3][0][0], board[2][1][1], board[1][2][2], board[0][3][3])) return true;
        if(CheckPlayer(player, board[3][3][0], board[2][2][1], board[1][1][2], board[0][0][3])) return true;
        if(CheckPlayer(player, board[3][0][3], board[2][1][2], board[1][2][1], board[0][3][0])) return true;
        if(CheckPlayer(player, board[0][3][3], board[1][2][2], board[2][1][1], board[3][0][0])) return true;


        // nothing
        return false;
    }

    internal static string PlayOX3D(List<(int, int, int)> moves)
    {
        var board = new int[4].Select(e => new int[4].Select(e => new int[4]).ToArray()).ToArray();
        for(var moveIndex = 0; moveIndex < moves.Count; ++moveIndex)
        {
            var (z, y, x) = moves[moveIndex];
            if(moveIndex % 2 == 0)
            {
                board[z][y][x] = PlayerO;
                if(IsPlayerWon(board, PlayerO)) return $"O wins after {moveIndex + 1} moves";
            }
            else
            {
                board[z][y][x] = PlayerX;
                if(IsPlayerWon(board, PlayerX)) return $"X wins after {moveIndex + 1} moves";
            }
        }
        return "No winner";
    }
}
