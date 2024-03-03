using NUnit.Framework;

namespace csharpweakevent;


[TestFixture]
public class SolutionTests
{
    [Test]
    public void TestWeakEvents()
    {
        // Arrange
        // Act
        Executor.ExecuteEventSequence();
        // Assert
    }
}

