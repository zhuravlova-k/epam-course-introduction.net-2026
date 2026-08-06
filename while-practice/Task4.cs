namespace WhilePractice;

public static class Task4
{
    public static double SumSequenceElements(int n)
    {
        double sum = 0.0;
        int i = 1;

        while (i <= n)
        {
            int baseValue = (2 * i) + 1;

            double denominator = 1.0;
            int j = 0;

            while (j < 2)
            {
                denominator *= baseValue;
                j++;
            }

            sum += 1.0 / denominator;

            i++;
        }

        return sum;
    }
}
