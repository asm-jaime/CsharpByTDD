namespace yandexcupfinal20242;

using System;

class Solution
{
    int[][] scrolls = new int[9][];
    int[] counts;
    int[][] grid;
    bool[][] used;

    public Solution()
    {
        scrolls[1] = new int[] { 1, 1 };
        scrolls[2] = new int[] { 1, 2 };
        scrolls[3] = new int[] { 1, 3 };
        scrolls[4] = new int[] { 1, 4 };
        scrolls[5] = new int[] { 2, 2 };
        scrolls[6] = new int[] { 2, 3 };
        scrolls[7] = new int[] { 2, 4 };
        scrolls[8] = new int[] { 3, 3 };
    }

    public bool Solve(int[][] grid)
    {
        this.grid = grid;
        used = new bool[10][];
        for(int i = 0; i < 10; i++)
        {
            used[i] = new bool[4];
        }
        counts = new int[8];
        return DFS();
    }

    bool DFS()
    {
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if(!used[i][j])
                {
                    int t = grid[i][j];
                    int h = scrolls[t][0];
                    int w = scrolls[t][1];

                    for(int dx = 0; dx < h; dx++)
                    {
                        for(int dy = 0; dy < w; dy++)
                        {
                            int ni = i - dx;
                            int nj = j - dy;
                            if(ni >= 0 && nj >= 0 && ni + h <= 10 && nj + w <= 4)
                            {
                                if(CanPlace(t, ni, nj))
                                {
                                    Place(t, ni, nj, true);
                                    counts[t - 1]++;
                                    if(DFS())
                                    {
                                        return true;
                                    }
                                    counts[t - 1]--;
                                    Place(t, ni, nj, false);
                                }
                            }
                        }
                    }
                    return false;
                }
            }
        }
        return true;
    }

    bool CanPlace(int t, int i, int j)
    {
        int h = scrolls[t][0];
        int w = scrolls[t][1];
        for(int x = i; x < i + h; x++)
        {
            for(int y = j; y < j + w; y++)
            {
                if(used[x][y] || grid[x][y] != t)
                {
                    return false;
                }
            }
        }
        return true;
    }

    void Place(int t, int i, int j, bool flag)
    {
        int h = scrolls[t][0];
        int w = scrolls[t][1];
        for(int x = i; x < i + h; x++)
        {
            for(int y = j; y < j + w; y++)
            {
                used[x][y] = flag;
            }
        }
    }

    public int[] GetCounts()
    {
        return counts;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int k = int.Parse(Console.ReadLine());
        for(int wall = 0; wall < k; wall++)
        {
            int[][] grid = new int[10][];
            for(int i = 0; i < 10; i++)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                grid[i] = new int[4];
                for(int j = 0; j < 4; j++)
                {
                    grid[i][j] = int.Parse(tokens[j]);
                }
            }
            var solution = new Solution();
            if(solution.Solve(grid))
            {
                Console.WriteLine("YES");
                int[] counts = solution.GetCounts();
                for(int i = 0; i < 8; i++)
                {
                    Console.Write(counts[i]);
                    if(i < 7) Console.Write(" ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
