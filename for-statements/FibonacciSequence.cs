namespace ForStatements;

public static class FibonacciSequence
{
    public static int GetFibonacciNumber(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return 1;
        }

        int prev = 0;
        int current = 1;

        for (int i = 2; i <= n; i++)
        {
            int next = prev + current;
            prev = current;
            current = next;
        }

        return current;
    }

    public static ulong GetProductOfFibonacciNumberDigits(ulong n)
    {
        if (n == 0)
        {
            return 0;
        }

        ulong prev = 0;
        ulong current = 1;

        for (ulong i = 2; i <= n; i++)
        {
            ulong next = prev + current;
            prev = current;
            current = next;
        }

        ulong product = 1;

        for (; current > 0; current /= 10)
        {
            product *= current % 10;
        }

        return product;
    }
}
