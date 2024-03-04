namespace artcritics;

public class Solution
{
    public static int CalculateBonus(int _, int[] scores)
    {
        int totalBonus = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            totalBonus += scores[i] * scores[i];

            int nonNullBonuses = scores[i];
            var j = i + 1;
            while (nonNullBonuses > 0 && j < scores.Length)
            {
                if (scores[j] > 0)
                {
                    nonNullBonuses--;
                }

                totalBonus += scores[j];

                j++;
            }
        }
        return totalBonus;
    }
}
