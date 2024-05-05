using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace infectedbynarytree;


[TestFixture]
class SolutionTests
{
    private static TreeNode CreateTree(int?[] arr)
    {
        if (arr == null || arr.Length == 0) return null;

        var root = new TreeNode(arr[0].Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        for (int i = 1; i < arr.Length; i += 2)
        {
            var current = queue.Dequeue();

            if (arr[i].HasValue)
            {
                current.left = new TreeNode(arr[i].Value);
                queue.Enqueue(current.left);
            }

            if (i + 1 < arr.Length && arr[i + 1].HasValue)
            {
                current.right = new TreeNode(arr[i + 1].Value);
                queue.Enqueue(current.right);
            }
        }

        return root;
    }

    [Test]
    [TestCase("[1,5,3,null,4,10,6,9,2]", 3, 4)]
    [TestCase("[1,2,3,null,5,null,4]", 5, 4)]
    [TestCase("[1,2,null,3,null,4,null,5]", 4, 3)]
    [TestCase("[2,3,null,4,1,null,null,null,5]", 1, 2)]
    public void TestAmountOfTime(string jsonTreeValues, int start, int expected)
    {
        // Deserialize the JSON string back to an array
        int?[] treeValues = JsonConvert.DeserializeObject<int?[]>(jsonTreeValues);

        // Arrange
        var solution = new Solution();
        TreeNode root = CreateTree(treeValues);

        // Act
        int totalTime = solution.AmountOfTime(root, start);

        // Assert
        Assert.AreEqual(expected, totalTime);
    }
}

