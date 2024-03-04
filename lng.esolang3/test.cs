using NUnit.Framework;
using System.Collections.Generic;

namespace lngesolang3;


[TestFixture]
public class EsolangHardTest
{
    /*
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 0, 6, 9, "000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000")
                                         .Returns("000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000")
                                         .SetDescription("Your interpreter should initialize all cells in the datagrid to 0");
            yield return new TestCaseData("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 7, 6, 9, "111100\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000")
                                         .Returns("111100\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000")
                                         .SetDescription("Your interpreter should adhere to the number of iterations specified");
            yield return new TestCaseData("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 19, 6, 9, "111100\r\n000010\r\n000001\r\n000010\r\n000100\r\n000000\r\n000000\r\n000000\r\n000000")
                                         .Returns("111100\r\n000010\r\n000001\r\n000010\r\n000100\r\n000000\r\n000000\r\n000000\r\n000000")
                                         .SetDescription("Your interpreter should traverse the 2D datagrid correctly");
            yield return new TestCaseData("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 42, 6, 9, "111100\r\n100010\r\n100001\r\n100010\r\n111100\r\n100000\r\n100000\r\n100000\r\n100000")
                                         .Returns("111100\r\n100010\r\n100001\r\n100010\r\n111100\r\n100000\r\n100000\r\n100000\r\n100000")
                                         .SetDescription("Your interpreter should traverse the 2D datagrid correctly for all of the \"n\", \"e\", \"s\" and \"w\" commands");
            yield return new TestCaseData("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 100, 6, 9, "111100\r\n100010\r\n100001\r\n100010\r\n111100\r\n100000\r\n100000\r\n100000\r\n100000")
                                         .Returns("111100\r\n100010\r\n100001\r\n100010\r\n111100\r\n100000\r\n100000\r\n100000\r\n100000")
                                         .SetDescription("Your interpreter should terminate normally and return a representation of the final state of the 2D datagrid when all commands have been considered from left to right even if the number of iterations specified have not been fully performed");
        }
    }
    */

    [Test, TestCaseSource("testCases")]
    public string Test(string code, int iterations, int width, int height, string _)
    {
        string actual = PaintFuck.Interpret(code, iterations, width, height);

        // Prints representation of datagrid - 0's are black and 1's are white
        // Note: Only works properly if your interpreter returns a representation of the datagrid in the correct format
        //Assert(expected, Is.EqualTo(actual));
        //Setup.DisplayExpected(expected);
        //Setup.DisplayActual(actual);

        return actual;
    }

    [Test]
    public void TestInstructionsOverflow()
    {
        Assert.That(PaintFuck.Interpret("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 100, 6, 9), Is.EqualTo("111100\r\n100010\r\n100001\r\n100010\r\n111100\r\n100000\r\n100000\r\n100000\r\n100000"));
    }
    [Test]
    public void TestOutOfMemory()
    {
        Assert.That(PaintFuck.Interpret("eee*s*s*s*w*w*w*w*w*w*w*n*n*n*n*n*n*n*n*n*e*e*e*e*e*e*e*s*s*s*s*s*", 1000, 8, 10), Is.EqualTo("111100\r\n100010\r\n100001\r\n100010\r\n111100\r\n100000\r\n100000\r\n100000\r\n100000"));
    }

    [Test]
    public void TestWrongInput()
    {
        Assert.That(PaintFuck.Interpret("o*e*eq*reqrqp*ppooqqeaqqsr*yqaooqqqfqarppppfffpppppygesfffffffffu*wrs*agwpffffst*w*uqrw*qyaprrrrrw*nuiiiid???ii*n*ynyy??ayd*r:rq????qq::tqaq:y???ss:rqsr?s*qs:q*?qs*tr??qst?q*r", 7, 6, 9), Is.EqualTo("111100\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000"));
    }

    [Test]
    public void TestWrongInput2()
    {
        Assert.That(PaintFuck.Interpret("*[es*]", 5, 5, 6), Is.EqualTo("10000\r\n01000\r\n00000\r\n00000\r\n00000\r\n00000"));
    }

    [Test]
    public void TestWrongInput3()
    {
        Assert.That(PaintFuck.Interpret("*[s[e]*]", 49, 5, 5), Is.EqualTo("11100\r\n11100\r\n11000\r\n11000\r\n11000"));
    }
}
