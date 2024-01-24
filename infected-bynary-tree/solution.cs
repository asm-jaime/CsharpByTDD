using System;
using System.Collections.Generic;
using System.Linq;

namespace infectedbynarytree;

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

public record class NodeData();


public class Solution
{
    public int AmountOfTime(TreeNode root, int start)
    {
        var maxPath = 0;
        TreeNode infected = new TreeNode();
        var infectedPath = 0;


        var stack = new Stack<(TreeNode, List<TreeNode>)>();
        stack.Push((root, new List<TreeNode>() { root }));

        while (stack.Count() > 0)
        {
            var (node, path) = stack.Pop();

            if (node.val == start)
            {
                infected = node;
                infectedPath = path.Count() - 1;
                break;
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

        stack = new Stack<(TreeNode, List<TreeNode>)>();
        stack.Push((root, new List<TreeNode>() { root }));

        while (stack.Count() > 0)
        {
            var (node, path) = stack.Pop();

            if (node.left is null && node.right is null && path.Contains(infected))
            {
                maxPath = Math.Max(maxPath, Math.Max(path.Count() - 1 - infectedPath, infectedPath));
            }

            if (node.left is null && node.right is null && path.Contains(infected) is false)
            {
                maxPath = Math.Max(maxPath, path.Count() - 1 + infectedPath);
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

        return maxPath;
    }
}
