using FluentAssertions;
using NUnit.Framework;

namespace csharpsequenceofexecution;


[TestFixture]
public class SequenceOfExecutionTest
{
    [Test]
    public void ShouldExecuteSequence()
    {
        var sequence = new SequenceOfExecution();
        var result = sequence.CalculateMain();
        result.Should().Be("12\r\n1");
    }
}

