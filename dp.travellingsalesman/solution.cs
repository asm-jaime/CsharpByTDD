using System;
using System.Collections.Generic;
using System.Linq;

namespace dptravellingsalesman;

class Vertex
{
    public int Id { private set; get; }
    public Vertex(int id)
    {
        Id = id;
    }
}

class TSP
{
    private static List<Int32> RecoverResult(Dictionary<Vertex, Vertex> minPathVertex, Vertex firstVertex)
    {
        var result = new List<Int32>() { firstVertex.Id };

        var reversedPath = new Dictionary<Vertex, Vertex>();
        foreach(var vertexPair in minPathVertex)
        {
            reversedPath[vertexPair.Value] = vertexPair.Key;
        }

        var vertex = firstVertex;
        while(reversedPath.TryGetValue(vertex, out _))
        {
            vertex = reversedPath[vertex];
            result.Add(vertex.Id);
        }

        result.Add(firstVertex.Id);

        return result;
    }

    public static List<Int32> Approximate(int[][] matrix)
    {
        var vertexes = Enumerable.Range(0, matrix.Length).Select(id => new Vertex(id)).ToArray();

        Dictionary<Vertex, bool> visitedVertexes = new();
        foreach(var vertex in vertexes) visitedVertexes[vertex] = false;

        var minLengthToVertex = new Dictionary<Vertex, int>();
        foreach(var vertex in vertexes) minLengthToVertex[vertex] = int.MaxValue;
        var minPathVertex = new Dictionary<Vertex, Vertex>();

        var vertexQueue = new Queue<Vertex>();
        vertexQueue.Enqueue(vertexes[0]);

        minLengthToVertex[vertexes[0]] = 0;

        while(vertexQueue.Count > 0)
        {
            var currentVertex = vertexQueue.Dequeue();
            visitedVertexes[currentVertex] = true;

            foreach(var vertex in vertexes)
            {
                if(visitedVertexes[vertex]) continue;

                if(minLengthToVertex[vertex] >= minLengthToVertex[currentVertex] + matrix[currentVertex.Id][vertex.Id])
                {
                    minLengthToVertex[vertex] = minLengthToVertex[currentVertex] + matrix[currentVertex.Id][vertex.Id];
                    minPathVertex[vertex] = currentVertex;
                }
                vertexQueue.Enqueue(vertex);
            }
        }

        var result = RecoverResult(minPathVertex, vertexes[0]);
        //var result = new List<Int32>();

        return result;
    }
}
