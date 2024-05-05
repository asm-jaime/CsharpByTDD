using NUnit.Framework;

namespace spiral;


[TestFixture]
class SolutionTest
{
    [Test]
    public void Test01()
    {
        int input = 1;
        int[,] expected = new int[,]
        {
            {1},
        };

        int[,] actual = Solution.Spiralize(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test02()
    {
        int input = 2;
        int[,] expected = new int[,]
        {
            {1, 1},
            {0, 1},
        };

        int[,] actual = Solution.Spiralize(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test03()
    {
        int input = 3;
        int[,] expected = new int[,]
        {
            {1, 1, 1},
            {0, 0, 1},
            {1, 1, 1},
        };

        int[,] actual = Solution.Spiralize(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test04()
    {
        int input = 4;
        int[,] expected = new int[,]
        {
            {1, 1, 1, 1 },
            {0, 0, 0, 1 },
            {1, 0, 0, 1 },
            {1, 1, 1, 1 },
        };

        int[,] actual = Solution.Spiralize(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test05()
    {
        int input = 5;
        int[,] expected = new int[,]
        {
            {1, 1, 1, 1, 1},
            {0, 0, 0, 0, 1},
            {1, 1, 1, 0, 1},
            {1, 0, 0, 0, 1},
            {1, 1, 1, 1, 1}
        };

        int[,] actual = Solution.Spiralize(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test08()
    {
        int input = 8;
        int[,] expected = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1},
            {0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 1, 0, 1},
            {1, 0, 1, 0, 0, 1, 0, 1},
            {1, 0, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1},
        };

        int[,] actual = Solution.Spiralize(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test09()
    {
        int input = 9;
        int[,] expected = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1},
            {0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 0, 1, 0, 1},
            {1, 0, 1, 1, 1, 0, 1, 0, 1},
            {1, 0, 1, 0, 0, 0, 1, 0, 1},
            {1, 0, 1, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1},
        };

        int[,] actual = Solution.Spiralize(input);
        Assert.AreEqual(expected, actual);
    }
}

