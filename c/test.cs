using NUnit.Framework;

namespace c
{
    [TestFixture]
    public class SolutionTests
    {
        [TestCase(2, 0, new[] { 99, 100 }, 2, 1)]
        [TestCase(2, 100, new[] { 99, 100 }, 2, 1)]
        [TestCase(5, 5, new[] { 1, 4, 9, 16, 25 }, 2, 24)]
        [TestCase(5, 0, new[] { 1, 4, 9, 16, 25 }, 2, 27)]
        [TestCase(5, 0, new[] { 1, 4, 9, 16, 25 }, 5, 24)]
        [TestCase(5, 0, new[] { 1, 4, 9, 16, 25 }, 1, 24)]
        [TestCase(5, 100, new[] { 1, 4, 9, 16, 25 }, 5, 24)]
        [TestCase(6, 4, new[] { 1, 2, 3, 6, 8, 25 }, 5, 31)]
        public void GetMinStairClimbed_WithValidInputs_ReturnsExpectedResult(int n, int timeTillLeave, int[] floors, int leavingEmployee, int expected)
        {
            // Arrange
            var solution = new Solution();

            // Act
            int result = solution.GetMinStairClimbed(n, timeTillLeave, floors, leavingEmployee);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

