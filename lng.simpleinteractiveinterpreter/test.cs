using NUnit.Framework;
using System;

namespace lngsimpleinteractiveinterpreter;

[TestFixture]
class InterpreterTests
{
    private static void Check(ref Interpreter interpret, string inp, double? res)
    {
        double? result;
        try { result = interpret.Input(inp); } catch(Exception) { result = null; }
        if(result != res) Assert.Fail("input(\"" + inp + "\") == <" + res + "> and not <" + result + "> => wrong solution, aborted!"); else Console.WriteLine("input(\"" + inp + "\") == <" + res + "> was ok");
    }

    [Test]
    public void BasicArithmeticTests()
    {
        Interpreter interpret = new();
        Check(ref interpret, "1 + 1", 2);
        Check(ref interpret, "2 - 1", 1);
        Check(ref interpret, "2 * 3", 6);
        Check(ref interpret, "8 / 4", 2);
        Check(ref interpret, "7 % 4", 3);
    }

    [Test]
    public void ComplexArithmeticTests()
    {
        Interpreter interpret = new();
        Check(ref interpret, "4 / 2 * 3", 6);
    }

    [Test]
    public void VariablesTests()
    {
        Interpreter interpret = new();
        Check(ref interpret, "x = 1", 1);
        Check(ref interpret, "x", 1);
        Check(ref interpret, "x + 3", 4);
        Check(ref interpret, "y", null);
    }

    [Test]
    public void FunctionsTests()
    {
        Interpreter interpret = new();
        Check(ref interpret, "fn avg x y => (x + y) / 2", null);
        Check(ref interpret, "avg 4 2", 3);
        Check(ref interpret, "avg 7", null);
        Check(ref interpret, "avg 7 2 4", null);
        Check(ref interpret, "fn echo x => x", null);
        Check(ref interpret, "avg echo 4 echo 2", 3);
    }

    [Test]
    public void ConflictsTests()
    {
        Interpreter interpret = new();
        Check(ref interpret, "fn x x => 0", null);
        Check(ref interpret, "fn avg => 0", null);
        Check(ref interpret, "avg = 5", null);
    }
}
