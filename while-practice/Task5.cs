namespace WhilePractice;

public static class Task5
{
    public static double GetSequenceProduct(int n)
    {
        double product = 1.0;
        int i = 1;

        while (i <= n)
        {
            double denominator = 1.0;
            int j = 0;
            while (j < 2)
            {
                denominator *= i;
                j++;
            }

            double factor = 1.0 + (1.0 / denominator);

            product *= factor;

            i++;
        }

        return product;
    }
}
