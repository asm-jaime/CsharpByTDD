namespace listremovenode;

class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

class Solution
{
    public int ListLength(ListNode head)
    {
        if(head is null) return 0;

        var len = 1;
        var current = head;
        while(current.next is not null)
        {
            len++;
            current = current.next;
        }
        return len;
    }

    private (ListNode, ListNode) GetNodeAndPrevNodeByNumber(ListNode head, int n)
    {
        var position = 0;
        var current = head;
        var previous = head;
        while(position < n)
        {
            position++;
            previous = current;
            current = current.next;
        }

        return (current, previous);
    }

    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        if(head is null || head.next is null)
        {
            return null;
        }

        var len = ListLength(head);

        if(len == n)
        {
            head = head.next;
            return head;
        }

        var (current, previous) = GetNodeAndPrevNodeByNumber(head, len - n);

        previous.next = current.next;
        current.next = null;

        return head;
    }
}
