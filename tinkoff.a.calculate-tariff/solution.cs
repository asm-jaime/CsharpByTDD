namespace a
{
    class Solution
    {
        public static int CalculateTotalCost(int a, int b, int c, int d)
        {
            int totalCost;

            if (d <= b)
            {
                totalCost = a;
            }
            else
            {
                int extraMB = d - b;
                totalCost = a + (extraMB * c);
            }

            return totalCost;
        }
    }
}
