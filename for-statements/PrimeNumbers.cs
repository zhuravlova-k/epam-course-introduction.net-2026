namespace ForStatements;

public static class PrimeNumbers
{
    public static bool IsPrimeNumber(uint n)
    {
        if (n <= 1)
        {
            return false;
        }

        for (uint i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static ulong SumDigitsOfPrimeNumbers(int start, int end)
    {
        ulong totalSum = 0;

        for (int i = start; i <= end; i++)
        {
            if (i <= 1)
            {
                continue;
            }

            bool isPrime = true;
            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (!isPrime)
            {
                continue;
            }

            for (int temp = i; temp > 0; temp /= 10)
            {
                totalSum += (ulong)(temp % 10);
            }
        }

        return totalSum;
    }
}
