using FluentAssertions;
using NUnit.Framework;

namespace listremovenode;


[TestFixture]
public class SolutionTests
{
    [Test]
    public void TestCalculate()
    {
        // Arrange
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        //var removeNode = 2;
        // Act
        int currentLength = Solution.ListLength(head);
        //int result = solution.RemoveNthFromEnd(head, removeNode);
        // Assert
        currentLength.Should().Be(4);

    }
}

