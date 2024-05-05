using System.Collections.Generic;

namespace infectedbynarytree;

class TreeNode
{
    internal int val;
    internal TreeNode left;
    internal TreeNode right;
    internal TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

class Solution
{
    internal int AmountOfTime(TreeNode root, int start)
    {
        var graph = new Dictionary<int, List<int>>();
        BuildGraph(root, null, graph);

        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        queue.Enqueue(start);
        visited.Add(start);

        int minutes = -1;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            minutes++;

            for (int i = 0; i < size; i++)
            {
                int current = queue.Dequeue();

                foreach (int neighbor in graph[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
        }

        return minutes;
    }

    private void BuildGraph(TreeNode node, TreeNode parent, Dictionary<int, List<int>> graph)
    {
        if (node == null) return;

        if (!graph.ContainsKey(node.val))
        {
            graph[node.val] = new List<int>();
        }

        if (parent != null)
        {
            graph[node.val].Add(parent.val);
            graph[parent.val].Add(node.val);
        }

        BuildGraph(node.left, node, graph);
        BuildGraph(node.right, node, graph);
    }
}
