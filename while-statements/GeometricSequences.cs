namespace WhileStatements;

public static class GeometricSequences
{
    public static uint SumGeometricSequenceTerms1(uint a, uint r, uint n)
    {
        uint sum = 0;
        uint i = 0;

        while (i < n)
        {
            uint power = 1;
            uint j = 0;

            while (j < i)
            {
                power *= r;
                j++;
            }

            sum += a * power;
            i++;
        }

        return sum;
    }

    public static uint SumGeometricSequenceTerms2(uint n)
    {
        const uint firstTerm = 13;
        const uint commonRatio = 3;

        uint sum = 0;
        uint i = 0;

        while (i < n)
        {
            uint power = 1;
            uint j = 0;

            while (j < i)
            {
                power *= commonRatio;
                j++;
            }

            sum += firstTerm * power;
            i++;
        }

        return sum;
    }

    public static uint CountGeometricSequenceTerms3(uint a, uint r, uint maxTerm)
    {
        uint count = 0;
        uint currentTerm = a;
        while (currentTerm <= maxTerm)
        {
            count++;
            currentTerm *= r;
        }

        return count;
    }

    public static uint CountGeometricSequenceTerms4(uint a, uint r, uint n, uint minTerm)
    {
        uint count = 0;
        uint currentTerm = a;
        uint i = 0;

        while (i < n)
        {
            if (currentTerm >= minTerm)
            {
                count++;
            }

            currentTerm *= r;
            i++;
        }

        return count;
    }
}
