namespace csharplocalfunction;

class Solution
{
    static int _parameter = 1;

    internal int Calculate(int a, int b)
    {
        static int Add(int a, int b)
        {
            return a + b + _parameter;
        }

        return Add(a, b);
    }
}
