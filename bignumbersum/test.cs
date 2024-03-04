using FluentAssertions;
using NUnit.Framework;

namespace bignumbersum;

[TestFixture]
public class BigNumberSumTest
{
    [TestCase("10", "10", "20")]
    [TestCase("91", "19", "110")]
    [TestCase("123456789", "987654322", "1111111111")]
    [TestCase("999999999", "1", "1000000000")]
    public void TestSum(string number1, string number2, string expectedSum)
    {
        Solution.Add(number1, number2).Should().Be(expectedSum);
    }
}
