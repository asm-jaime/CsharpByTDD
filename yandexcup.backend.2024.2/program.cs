using System;
using System.Linq;

namespace yandexcupbackend20242
{
    class Solution
    {
        internal int ModInverse(int a, int mod)
        {
            int m0 = mod, t, q;
            int x0 = 0, x1 = 1;

            if (mod == 1)
                return 0;

            while (a > 1)
            {
                q = a / mod;
                t = mod;

                mod = a % mod;
                a = t;
                t = x0;

                x0 = x1 - q * x0;
                x1 = t;
            }

            if (x1 < 0)
                x1 += m0;

            return x1;
        }

        internal int Mod(int a, int mod)
        {
            int result = a % mod;
            if (result < 0)
                result += mod;
            return result;
        }

        internal int[,] BuildMatrix(int[] xj, int m)
        {
            int[,] M = new int[m, m];
            int mod = 23;

            for (int j = 0; j < m; j++)
            {
                int x_mod = Mod(xj[j], mod);
                int x_pow = 1;

                for (int k = 0; k < m; k++)
                {
                    if (k > 0)
                        x_pow = Mod(x_pow * x_mod, mod);

                    M[j, k] = x_pow;
                }
            }

            return M;
        }

        internal int[] SolveSystem(int[,] M, int[] b, int mod)
        {
            int m = b.Length;
            int[] a = new int[m];
            for (int i = 0; i < m; i++)
                a[i] = -1;

            // Gaussian elimination
            for (int k = 0; k < m; k++)
            {
                // Find pivot
                int maxRow = k;
                for (int i = k + 1; i < m; i++)
                {
                    if (M[i, k] != 0)
                    {
                        maxRow = i;
                        break;
                    }
                }

                // Swap rows if needed
                if (M[maxRow, k] == 0)
                    continue;

                if (maxRow != k)
                {
                    for (int j = 0; j < m; j++)
                    {
                        int temp = M[k, j];
                        M[k, j] = M[maxRow, j];
                        M[maxRow, j] = temp;
                    }
                    int tempB = b[k];
                    b[k] = b[maxRow];
                    b[maxRow] = tempB;
                }

                // Normalize pivot row
                int inv = ModInverse(M[k, k], mod);
                for (int j = k; j < m; j++)
                {
                    M[k, j] = Mod(M[k, j] * inv, mod);
                }
                b[k] = Mod(b[k] * inv, mod);

                // Eliminate
                for (int i = 0; i < m; i++)
                {
                    if (i != k && M[i, k] != 0)
                    {
                        int factor = M[i, k];
                        for (int j = k; j < m; j++)
                        {
                            M[i, j] = Mod(M[i, j] - factor * M[k, j], mod);
                        }
                        b[i] = Mod(b[i] - factor * b[k], mod);
                    }
                }
            }

            // Extract solutions
            for (int i = 0; i < m; i++)
            {
                a[i] = b[i];
                if (a[i] < 0 || a[i] >= mod)
                    a[i] = Mod(a[i], mod);
            }

            return a;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int mod = 23;

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[] xj = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bj = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] M = solution.BuildMatrix(xj, m);
            int[] a_vars = solution.SolveSystem(M, bj, mod);

            int[] a_i = new int[n];
            for (int i = 0; i < n; i++)
                a_i[i] = 0;

            for (int i = 0; i < m; i++)
            {
                a_i[i] = a_vars[i];
            }

            char[] password = new char[n];
            for (int i = 0; i < n; i++)
            {
                password[i] = (char)('a' + a_i[i]);
            }

            Console.WriteLine(new string(password));
        }
    }
}

