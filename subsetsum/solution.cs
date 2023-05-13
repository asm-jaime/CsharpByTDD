namespace subsum
{
    public class Solution
    {
        public bool IsSumPassable(int[] nums, int target)
        {
            bool[,] dp = new bool[nums.Length, target + 1];

            for (int i = 0; i < nums.Length; i++) dp[i, 0] = true;
            for (int j = 1; j <= target; j++) dp[0, j] = false;

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 1; j <= target; j++)
                {
                    if (j >= nums[i])
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i]];
                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }

            return dp[nums.Length - 1, target];
        }
    }
}
