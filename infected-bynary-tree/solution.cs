using System.Collections.Generic;

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

public class Solution
{
    public int AmountOfTime(TreeNode root, int start)
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        BuildGraph(root, null, graph);

        Queue<int> queue = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();
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
