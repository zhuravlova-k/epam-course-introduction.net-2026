namespace WhilePractice;

public static class Task3
{
    public static double SumSequenceElements(int n)
    {
        double sum = 0.0;
        int i = 1;

        while (i <= n)
        {
            double denominator = 1.0;
            int j = 0;

            while (j < 5)
            {
                denominator *= i;
                j++;
            }

            sum += 1.0 / denominator;

            i++;
        }

        return sum;
    }
}
