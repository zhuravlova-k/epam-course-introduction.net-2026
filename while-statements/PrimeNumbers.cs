namespace WhileStatements;

public static class PrimeNumbers
{
    public static bool IsPrimeNumber(uint n)
    {
        if (n <= 1)
        {
            return false;
        }

        uint i = 2;

        while (i <= n / i)
        {
            if (n % i == 0)
            {
                return false;
            }

            i++;
        }

        return true;
    }

    public static uint GetLastPrimeNumber(uint n)
    {
        uint current = n;

        while (current > 1)
        {
            if (IsPrimeNumber(current))
            {
                return current;
            }

            current--;
        }

        return 0;
    }

    public static uint SumLastPrimeNumbers(uint n, uint count)
    {
        uint sum = 0;
        uint primesFound = 0;
        uint current = n;

        while (current > 1 && primesFound < count)
        {
            if (IsPrimeNumber(current))
            {
                sum += current;
                primesFound++;
            }

            current--;
        }

        return sum;
    }
}
