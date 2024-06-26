﻿using System.Collections.Generic;

namespace csharpbinarythree;

class Node
{
    internal Node Left;
    internal Node Right;
    internal int Value;

    internal Node(Node l, Node r, int v)
    {
        Left = l;
        Right = r;
        Value = v;
    }
}

class TreeWalker
{
    internal static List<int> TreeByLevelsDeep(Node mainNode)
    {
        var result = new List<int>();

        if(mainNode == null) return result;

        void recursiveWalker(Node node)
        {
            if(node is null) return;
            result.Add(node.Value);

            recursiveWalker(node.Left);
            recursiveWalker(node.Right);
        }

        recursiveWalker(mainNode);

        return result;
    }

    internal static List<int> TreeByLevels(Node mainNode)
    {
        var result = new List<int>();

        if(mainNode == null) return result;

        var queue = new Queue<Node>();
        queue.Enqueue(mainNode);

        while(queue.Count > 0)
        {
            var current = queue.Dequeue();
            if(current is null) continue;

            result.Add(current.Value);

            queue.Enqueue(current.Left);
            queue.Enqueue(current.Right);

        }

        return result;
    }
}
