using System.Numerics;

namespace dpheightandegg;

public static class Faberge
{
    public static BigInteger SimpleHeight(int eggs, int tries)
    {
        if(eggs == 0 || tries == 0) return 0;

        BigInteger[,] heightsTable = new BigInteger[eggs, tries];

        for(int egg = 0; egg < eggs; ++egg)
        {
            for(int shot = 0; shot < tries; ++shot)
            {
                if(shot == 0)
                {
                    heightsTable[egg, shot] = 1;
                    continue;
                }
                if(egg == 0)
                {
                    heightsTable[egg, shot] = 1 + shot;
                    continue;
                }

                BigInteger ifEggCracked = heightsTable[egg - 1, shot - 1];
                BigInteger ifEggSurvived = heightsTable[egg, shot - 1];

                heightsTable[egg, shot] = 1 + ifEggCracked + ifEggSurvived;
            }
        }

        return heightsTable[eggs - 1, tries - 1];
    }

    public static BigInteger OptimizedHeight(int eggs, int tries)
    {
        if(eggs == 0 || tries == 0) return 0;

        BigInteger[,] heightsTable = new BigInteger[2, tries];

        int rowCurr = 0;
        int rowPrev = 1;


        for(int egg = 0; egg < eggs; ++egg)
        {
            for(int shot = 0; shot < tries; ++shot)
            {
                if(egg % 2 == 0)
                {
                    rowCurr = 0;
                    rowPrev = 1;
                }
                else
                {
                    rowCurr = 1;
                    rowPrev = 0;
                }

                if(shot == 0)
                {
                    heightsTable[rowCurr, shot] = 1;
                    continue;
                }

                if(egg == 0)
                {
                    heightsTable[0, shot] = 1 + shot;
                    continue;
                }

                /*
                BigInteger ifEggCracked = heightsTable[rowPrev, shot - 1];
                BigInteger ifEggSurvived = heightsTable[rowCurr, shot - 1];
                */

                heightsTable[rowCurr, shot] = 1 +
                    BigInteger.Add(
                        heightsTable[rowPrev, shot - 1],
                        heightsTable[rowCurr, shot - 1]
                    )
                ;
            }
        }

        return heightsTable[rowCurr, tries - 1];
    }


    public static BigInteger FastHeight(int eggs, int tries)
    {
        if(eggs == 0 || tries == 0) return 0;

        BigInteger multiplicator = tries;

        BigInteger current = tries;

        for(int egg = 1; egg < eggs; ++egg)
        {
            multiplicator = multiplicator * (tries - egg) / (egg + 1);

            current = current + multiplicator;
        }

        return current;
    }


    public static BigInteger Height1(BigInteger eggs, BigInteger tries)
    {
        if(eggs == 0 || tries == 0) return 0;

        tries = tries % Mod;

        BigInteger multiplicator = tries;
        BigInteger current = tries;

        for(BigInteger egg = 1; egg < eggs; ++egg)
        {
            multiplicator = multiplicator * (tries - egg) / (egg + 1);
            //multiplicator = BigInteger.Multiply(multiplicator, (tries - egg) / (egg + 1));

            current = current + multiplicator;
        }

        return current % Mod;
    }


    private const int Mod = 998244353;
    private const int MaximalEggs = 80001;

    private static int[] Multicators = new int[MaximalEggs];

    private static void FillMiltiplicator()
    {
        Multicators[0] = 0;
        Multicators[1] = 1;

        for(int index = 2; index < 80001; ++index)
        {
            Multicators[index] = (int)(((Mod - (Mod / index)) * (BigInteger)Multicators[(Mod % index)]) % Mod);
        }
    }

    public static BigInteger Height(BigInteger eggs, BigInteger tries)
    {
        if(eggs == 0 || tries == 0) return 0;

        FillMiltiplicator();

        BigInteger height = 0;
        BigInteger trial = 1;

        tries = tries % Mod;

        for(int egg = 1; egg <= eggs; ++egg)
        {
            trial = trial * (tries - egg + 1) * Multicators[egg] % Mod;
            height = (height + trial) % Mod;
        }

        return height % Mod;
    }
}
