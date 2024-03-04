namespace listremovenode;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public static int ListLength(ListNode head)
    {
        var len = 0;
        var current = head;
        while(current.next is not null)
        {
            len++;
            current = current.next;
        }
        return len;
    }

    public static ListNode RemoveNthFromEnd(ListNode head, int _)
    {
        return head;
    }
}
