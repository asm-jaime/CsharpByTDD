namespace dpfibbonacci;

public static class FibonacciEvenSum
{
    public static long Fibonacci(int max)
    {
        long first = 0;
        long second = 1;
        long result = 1;
        long sum = 0;
        for(int i = 2; result < max; i++)
        {
            if(i % 3 == 0) sum = sum + result;
            first = second;
            second = result;
            result = first + second;
        }
        return sum;
    }
}
