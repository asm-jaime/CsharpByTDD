using System;
using System.Collections.Generic;
using System.Linq;

namespace gametictactoeai;

    class TTTSolver
    {
        private const int Player = 1;
        private const int PlayerScore = 10;
        private const int Opponent = 2;
        private const int OpponentScore = -10;
        private const int StalemateScore = 0;
        private const int DefaultBoardState = 0;

        private static readonly Dictionary<int, Func<int, int, int>> _optimization =
            new() {
                {Player, Math.Max},
                {Opponent, Math.Min}
            };

        private static readonly Dictionary<string, int[]> _chache = new() {
            {"0 0 0\n0 0 0\n0 0 01", new int[]{1, 1}}
        };

        private static int GetEnemyPlayer(int player) => player switch
        {
            Player => Opponent,
            Opponent => Player,
            _ => Player,
        };

        private static int GetMaxScoreByPlayer(int player) => player switch
        {
            Player => -1000,
            Opponent => 1000,
            _ => 0,
        };

        private static string GetStringFromBoardState(int[][] board) => board
            .Select(row => row.Select(num => num.ToString()).Aggregate((acc, num) => $"{acc} {num}"))
            .Aggregate((acc, row) => $"{acc}\n{row}");

        private static bool CheckPlayer(int player, params int[] cell) =>
            cell.Select(element => element.Equals(player)).Aggregate((acc, element) => acc && element);

        private static bool IsPlayerWon(int[][] board, int player)
        {
            // rows
            for (int row = 0; row < board.Length; row++)
                if (CheckPlayer(player, board[row][0], board[row][1], board[row][2])) return true;
            // cols
            for (int col = 0; col < board.Length; col++)
                if (CheckPlayer(player, board[0][col], board[1][col], board[2][col])) return true;
            // cross
            if (CheckPlayer(player, board[0][0], board[1][1], board[2][2])) return true;
            if (CheckPlayer(player, board[2][0], board[1][1], board[0][2])) return true;
            // nothing
            return false;
        }

        private static bool IsMovesLeft(int[][] board)
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col].Equals(0)) return true;
                }
            }
            return false;
        }

        private static int MiniMax(int[][] board, int player)
        {
            if (IsPlayerWon(board, Player)) return PlayerScore;
            if (IsPlayerWon(board, Opponent)) return OpponentScore;
            if (IsMovesLeft(board).Equals(false)) return StalemateScore;
;

            int bestScore = GetMaxScoreByPlayer(player);
            for (int row = 0; row < board.Length; ++row)
            {
                for (int col = 0; col < board[row].Length; ++col)
                {
                    if (board[row][col] == 0)
                    {
                        board[row][col] = player;
                        var score = MiniMax(board, GetEnemyPlayer(player));
                        bestScore = _optimization[player](bestScore, score);
                        board[row][col] = DefaultBoardState;
                    }
                }
            }
            return bestScore;
        }

        public static int[] TurnMethod(int[][] board, int player)
        {
            int bestScore = GetMaxScoreByPlayer(player);
            var bestMove = new int[] { -1, -1 };

            var gameState = $"{GetStringFromBoardState(board)}{player}";

            if (_chache.ContainsKey(gameState)) return _chache[gameState];

            for (int row = 0; row < board.Length; ++row)
            {
                for (int col = 0; col < board[row].Length; ++col)
                {
                    if (board[row][col] == 0)
                    {
                        board[row][col] = player;
                        var score = MiniMax(board, GetEnemyPlayer(player));
                        board[row][col] = 0;

                        if (score > bestScore)
                        {
                            bestMove = new int[] { row, col };
                            bestScore = score;
                        }
                    }
                }
            }

            _chache[gameState] = bestMove;
            return bestMove;
        }

    }
