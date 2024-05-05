using NUnit.Framework;
using System.Collections.Generic;

namespace gametictactoe3d;


[TestFixture]
class ExampleTests
{
    [Test]
    public void NoMoves()
    {
        Assert.AreEqual("No winner", Dinglemouse.PlayOX3D(new List<(int, int, int)>()));
    }

    [Test]
    public void NotManyMoves()
    {
        var moves = new List<(int, int, int)> { (0, 0, 0), (1, 1, 1), (2, 2, 2), (3, 3, 3) };
        Assert.AreEqual("No winner", Dinglemouse.PlayOX3D(moves));
    }

    [Test]
    public void OWins()
    {
        var moves = new List<(int, int, int)> { (0, 2, 1), (0, 2, 2), (1, 2, 1), (1, 2, 2), (2, 2, 1), (2, 2, 2), (3, 2, 1) };
        Assert.AreEqual("O wins after 7 moves", Dinglemouse.PlayOX3D(moves));
    }

    [Test]
    public void XWins()
    {
        var moves = new List<(int, int, int)> { (0, 1, 1), (0, 0, 0), (0, 2, 2), (1, 1, 1), (1, 2, 2), (2, 2, 2), (2, 1, 2), (3, 3, 3), (0, 2, 1) };
        Assert.AreEqual("X wins after 8 moves", Dinglemouse.PlayOX3D(moves));
    }

    [Test]
    public void XWinsAfter32Moves()
    {
        var moves = new List<(int, int, int)> {
                (3,1,0),
                (0,1,3),
                (1,1,3),
                (1,3,3),
                (2,1,1),
                (0,0,0),
                (1,2,3),
                (2,2,3),
                (1,1,1),
                (1,1,2),
                (3,1,3),
                (2,0,2),
                (3,0,1),
                (2,1,0),
                (1,2,1),
                (2,3,0),
                (2,3,3),
                (2,0,3),
                (2,0,0),
                (3,0,0),
                (2,0,1),
                (2,2,1),
                (1,0,0),
                (0,0,1),
                (0,3,0),
                (1,3,2),
                (2,1,3),
                (3,0,3),
                (1,0,3),
                (0,0,3),
                (1,0,2),
                (0,0,2),
                (3,1,2),
                (0,3,2),
                (1,3,0),
                (2,3,1),
                (0,1,1),
            };
        Assert.AreEqual("X wins after 32 moves", Dinglemouse.PlayOX3D(moves));
    }
}
