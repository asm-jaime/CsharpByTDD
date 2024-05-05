using NUnit.Framework;

namespace csharpweakevent;


[TestFixture]
class SolutionTests
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

