using System.Collections.Generic;
using System.Linq;

namespace treepalindromicpath;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public static int PseudoPalindromicPaths(TreeNode root)
    {
        var stack = new Stack<(TreeNode, List<TreeNode>)>();
        stack.Push((root, new List<TreeNode>() { root }));

        var result = 0;

        while (stack.Count > 0)
        {
            var (node, path) = stack.Pop();


            if (node.left is null && node.right is null && IsPathPalindromic(path))
            {
                result++;
            }

            if (node.left is not null)
            {
                var leftPath = new List<TreeNode>(path) { node.left };
                stack.Push((node.left, leftPath));
            }

            if (node.right is not null)
            {
                var rightPath = new List<TreeNode>(path) { node.right };
                stack.Push((node.right, rightPath));
            }
        }

        return result;
    }

    private static bool IsPathPalindromic(List<TreeNode> path)
    {
        var coincidences = path.GroupBy(e => e.val).Select(g => g.Count());
        if (path.Count % 2 is 0)
        {
            return coincidences.All(c => c % 2 is 0);
        }
        else
        {
            var isOddOnce = coincidences.Where(c => c % 2 is not 0).Count() is 1;
            //var isEvenAllExceptOneOdd = coincidences.Where(c => c % 2 is 0).Count + 1 == coincidences.Count;
            return isOddOnce;
        }
    }
}
