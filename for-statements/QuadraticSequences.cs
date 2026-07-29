namespace ForStatements;

public static class QuadraticSequences
{
    public static uint CountQuadraticSequenceTerms(long a, long b, long c, long maxTerm)
    {
        uint count = 0;

        for (long n = 1; ; n++)
        {
            long term = (a * n * n) + (b * n) + c;

            if (term <= maxTerm)
            {
                count++;
            }
            else
            {
                break;
            }
        }

        return count;
    }

    public static ulong GetQuadraticSequenceTermsProduct1(uint count)
    {
        const ulong a = 7;
        const ulong b = 4;
        const ulong c = 2;

        ulong product = 1;

        for (ulong n = 1; n <= count; n++)
        {
            ulong term = (a * n * n) + (b * n) + c;
            product *= term;
        }

        return product;
    }

    public static ulong GetQuadraticSequenceProduct2(long a, long b, long c, long startN, long count)
    {
        ulong product = 1;
        long endN = startN + count;
        for (long n = startN; n < endN; n++)
        {
            ulong term = (ulong)((a * n * n) + (b * n) + c);
            product *= term;
        }

        return product;
    }
}
