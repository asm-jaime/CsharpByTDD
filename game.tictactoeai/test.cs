using NUnit.Framework;

namespace gametictactoeai;


[TestFixture]
public class GameTicTacToeSolverTests
{
    [Test]
    public void TestOneField()
    {
        var board = new int[][]
        {
                new int[] { 0, 2, 1 },
                new int[] { 1, 2, 2 },
                new int[] { 2, 1, 1 }
        };
        Assert.AreEqual(new int[] { 0, 0 }, TTTSolver.TurnMethod(board, 1));
    }


    [Test]
    public void TestEmptyShallPutCentral()
    {
        var board = new int[][]
        {
                new int[] { 0, 0, 0 },
                new int[] { 0, 0, 0 },
                new int[] { 0, 0, 0 }
        };
        Assert.AreEqual(new int[] { 1, 1 }, TTTSolver.TurnMethod(board, 1));
    }

    [Test]
    public void TestBestMove22()
    {
        var board = new int[][]
        {
                new int[] { 1, 2, 1 },
                new int[] { 2, 2, 1 },
                new int[] { 0, 0, 0 }
        };
        Assert.AreEqual(new int[] { 2, 2 }, TTTSolver.TurnMethod(board, 1));
    }

    /*
    [Test]
    public void TestVsNextFreeStart1()
    {
        var game = new Game(GameTicTacToeSolver.TurnMethod, NextFreeSolver.TurnMethod);
        game.Run(1, true); // 1 => Player 1 starts, true => Always visualization (instead of only in case of failing)
    }

    [Test]
    public void TestVsNextFreeStart1_5runs()
    {
        for (int r = 0; r < 5; r++)
        {
            var game = new Game(GameTicTacToeSolver.TurnMethod, NextFreeSolver.TurnMethod);
            game.Run(1, false);
        }
    }

    [Test]
    public void TestVsNextFreeStart2()
    {
        var game = new Game(GameTicTacToeSolver.TurnMethod, NextFreeSolver.TurnMethod);
        game.Run(2, true);
    }

    [Test]
    public void TestVsStupidLuckyStart1()
    {
        var game = new Game(GameTicTacToeSolver.TurnMethod, StupidLuckySolver.TurnMethod);
        game.Run(1, true);
    }
    */
}
