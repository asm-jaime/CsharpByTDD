using FluentAssertions;
using NUnit.Framework;

namespace listremovenode;


[TestFixture]
class SolutionTests
{

    [Test]
    public void Test1Node()
    {
        // Arrange
        var solution = new Solution();
        var head = new ListNode(1);
        // Act
        var list = solution.RemoveNthFromEnd(head, 1);
        // Assert
        solution.ListLength(list).Should().Be(0);

    }

    [Test]
    public void Test2Node()
    {
        // Arrange
        var solution = new Solution();
        var head = new ListNode(1, new ListNode(2));
        //var removeNode = 2;
        // Act
        var list = solution.RemoveNthFromEnd(head, 1);
        // Assert
        solution.ListLength(list).Should().Be(1);

    }

    [Test]
    public void Test2NodeRemove2()
    {
        // Arrange
        var solution = new Solution();
        var head = new ListNode(1, new ListNode(2));
        // Act
        var list = solution.RemoveNthFromEnd(head, 2);
        // Assert
        solution.ListLength(list).Should().Be(1);
        list.val.Should().Be(2);

    }

    [Test]
    public void TestCalculate()
    {
        // Arrange
        var solution = new Solution();
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        // Act
        var list = solution.RemoveNthFromEnd(head, 2);
        // Assert
        solution.ListLength(list).Should().Be(4);

    }
}

