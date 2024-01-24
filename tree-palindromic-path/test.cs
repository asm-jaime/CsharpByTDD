using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace treepalindromicpath;


[TestFixture]
public class SolutionTests
{
    private TreeNode CreateTree(int?[] arr)
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
    [TestCase("[2,3,1,3,1,null,1]", 2)]
    [TestCase("[2,1,1,1,3,null,null,null,null,null,1]", 1)]
    public void TestCountPalindromic(string jsonTreeValues, int expected)
    {
        // Deserialize the JSON string back to an array
        int?[] treeValues = JsonConvert.DeserializeObject<int?[]>(jsonTreeValues);

        // Arrange
        Solution solution = new Solution();
        TreeNode root = CreateTree(treeValues);

        // Act
        int palindromicPathTime = solution.PseudoPalindromicPaths(root);

        // Assert
        Assert.AreEqual(expected, palindromicPathTime);
    }
}
