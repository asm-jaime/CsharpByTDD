using NUnit.Framework;
using System;

namespace csharpMSILMethod;


[TestFixture]
public class DynamicMethodUsingMSILSampleTests
{

    [Test]
    public void MulBy2AndAdd1_CastedToFuncOfIntntAndInt_DoesNotThrow()
    {
        static void action()
        {
            var x = (Func<int, int>)DynamicMethodUsingMSIL.MulBy2AndAdd1().CreateDelegate(typeof(Func<int, int>));
        }

        Assert.DoesNotThrow(action);
    }

    [Test]
    public void MulBy2AndAdd1_InvokedPassingIn2_Returns5()
    {
        var method = (Func<int, int>)DynamicMethodUsingMSIL.MulBy2AndAdd1().CreateDelegate(typeof(Func<int, int>));

        var result = method(2);


        Assert.That(result, Is.EqualTo(MulBy2AndAdd1CSharp(2)));
    }

    private static int MulBy2AndAdd1CSharp(int n) => 2 * n + 1;
}
