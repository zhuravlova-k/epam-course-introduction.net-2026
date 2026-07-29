namespace ForStatements;

public static class GeometricSequences
{
    public static ulong GetGeometricSequenceTermsProduct(uint a, uint r, uint n)
    {
        ulong product = 1;

        for (uint i = 0; i < n; i++)
        {
            ulong rpow = 1;

            for (uint j = 0; j < i; j++)
            {
                rpow *= r;
            }

            ulong currentTerm = a * rpow;
            product *= currentTerm;
        }

        return product;
    }

    public static ulong SumGeometricSequenceTerms(uint n)
    {
        const uint a = 5;
        const uint r = 3;

        ulong sum = 0;
        ulong currentTerm = a;

        for (uint i = 0; i < n; i++)
        {
            sum += currentTerm;
            currentTerm *= r;
        }

        return sum;
    }

    public static ulong CountGeometricSequenceTerms1(uint a, uint r, uint maxTerm)
    {
        ulong count = 0;
        ulong term = a;

        for (; term <= maxTerm;)
        {
            count++;
            term *= r;
        }

        return count;
    }

    public static ulong CountGeometricSequenceTerms2(uint a, uint r, uint n, uint minTerm)
    {
        uint i = 0;
        ulong term = a;

        for (; ;)
        {
            if (i == n || term >= minTerm)
            {
                break;
            }

            term *= r;
            i++;
        }

        return n - i;
    }
}
