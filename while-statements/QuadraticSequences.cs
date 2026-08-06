namespace WhileStatements;

public static class QuadraticSequences
{
    public static long SumQuadraticSequenceTerms1(long a, long b, long c, long maxTerm)
    {
        long sum = 0;
        long n = 1;

        long currentTerm = (a * n * n) + (b * n) + c;

        while (currentTerm <= maxTerm)
        {
            sum += currentTerm;

            n++;
            currentTerm = (a * n * n) + (b * n) + c;
        }

        return sum;
    }

    public static long SumQuadraticSequenceTerms2(long a, long b, long c, long startN, long count)
    {
        long sum = 0;
        long n = startN;
        long i = 0;

        while (i < count)
        {
            long currentTerm = (a * n * n) + (b * n) + c;
            sum += currentTerm;

            n++;
            i++;
        }

        return sum;
    }
}
