using NUnit.Framework;

namespace lngmathdifferentiation;


[TestFixture]
public class SolutionTest
{
    [Test]
    public void SimpleTests()
    {
        PrefixDiff diff = new PrefixDiff();

        Assert.AreEqual("0", diff.Diff("5"), "constant should return 0");
        Assert.AreEqual("1", diff.Diff("x"), "x should return 1");
        Assert.AreEqual("2", diff.Diff("(+ x x)"), "x+x should return 2");
        Assert.AreEqual("0", diff.Diff("(- x x)"), "x-x should return 0");
        Assert.AreEqual("2", diff.Diff("(* x 2)"), "2*x should return 2");
        Assert.AreEqual("0.5", diff.Diff("(/ x 2)"), "x/2 should return 0.5");
        Assert.AreEqual("(* 2 x)", diff.Diff("(^ x 2)"), "x^2 should return 2*x");
        Assert.AreEqual("(* -1 (sin x))", diff.Diff("(cos x)"), "cos(x) should return -1 * sin(x)");
        Assert.AreEqual("(cos x)", diff.Diff("(sin x)"), "sin(x) should return cos(x)");

        string result = diff.Diff("(tan x)");
        Assert.IsTrue((result == "(+ 1 (^ (tan x) 2))" || result == "(^ (cos x) -2)" || result == "(/ 1 (^ (cos x) 2))"),
          "Expected (+ 1 (^ (tan x) 2)) or (^ (cos x) -2) or (/ 1 (^ (cos x) 2)) but got " + result);

        Assert.AreEqual("(exp x)", diff.Diff("(exp x)"), "exp(x) should return exp(x)");
        Assert.AreEqual("(/ 1 x)", diff.Diff("(ln x)"), "ln(x) should return 1/x");
    }

    [Test]
    public void NestedExpressions()
    {
        PrefixDiff diff = new PrefixDiff();

        Assert.AreEqual("3", diff.Diff("(+ x (+ x x))"), "x+(x+x) should return 3");
        Assert.AreEqual("1", diff.Diff("(- (+ x x) x)"), "(x+x)-x should return 1");
        Assert.AreEqual("2", diff.Diff("(* 2 (+ x 2))"), "2*(x+2) should return 2");
        Assert.AreEqual("(/ -2 (^ (+ 1 x) 2))", diff.Diff("(/ 2 (+ 1 x))"), "2/(1+x) should return -2/(1+x)^2");
        Assert.AreEqual("(* -1 (sin (+ x 1)))", diff.Diff("(cos (+ x 1))"), "cos(x+1) should return -1 * sin(x+1)");

        string result = diff.Diff("(cos (* 2 x))");
        Assert.IsTrue((result == "(* 2 (* -1 (sin (* 2 x))))" || result == "(* -2 (sin (* 2 x)))"),
          "Expected (* 2 (* -1 (sin (* 2 x)))) or (* -2 (sin (* 2 x))) but got " + result);

        Assert.AreEqual("(cos (+ x 1))", diff.Diff("(sin (+ x 1))"), "sin(x+1) should return cos(x+1)");
        Assert.AreEqual("(* 2 (cos (* 2 x)))", diff.Diff("(sin (* 2 x))"), "sin(2*x) should return 2*cos(2*x)");

        result = diff.Diff("(tan (* 2 x))");
        Assert.IsTrue((result == "(* 2 (+ 1 (^ (tan (* 2 x)) 2)))" || result == "(* 2 (^ (cos (* 2 x)) -2))" || result == "(/ 2 (^ (cos (* 2 x)) 2))"),
          "Expected (* 2 (+ 1 (^ (tan (* 2 x)) 2))) or (* 2 (^ (cos (* 2 x)) -2)) or (/ 2 (^ (cos (* 2 x)) 2)) but got " + result);

        Assert.AreEqual("(* 2 (exp (* 2 x)))", diff.Diff("(exp (* 2 x))"), "exp(2*x) should return 2*exp(2*x)");
    }

    [Test]
    public void SecondDerivatives()
    {
        PrefixDiff diff = new PrefixDiff();

        Assert.AreEqual("(* -1 (sin x))", diff.Diff(diff.Diff("(sin x)")), "Second deriv. sin(x) should return -1 * sin(x)");
        Assert.AreEqual("(exp x)", diff.Diff(diff.Diff("(exp x)")), "Second deriv. exp(x) should return exp(x)");

        string result = diff.Diff(diff.Diff("(^ x 3)"));
        Assert.IsTrue((result == "(* 3 (* 2 x))" || result == "(* 6 x)"), "Expected (* 3 (* 2 x)) or (* 6 x) but got " + result);
    }
}
