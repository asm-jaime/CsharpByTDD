using FluentAssertions;
using NUnit.Framework;

namespace csharpexceptionsequence;


[TestFixture]
class TryTryCatchCatchFinallyTests
{
    [Test]
    public void TryTryCatchCatchFinally()
    {
        // Arrange
        var solution = new TryTryCatchCatchFinally();
        // Act
        var result = solution.GetExceptionSequenceString();
        // Assert
        result.Should().Be(typeof(E3).Name);
    }
}

