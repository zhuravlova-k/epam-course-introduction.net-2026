namespace WhilePractice;

public static class Task6
{
    public static double SumSequenceElements(int n)
    {
        double sum = 0.0;
        int i = 1;
        double sign = -1.0;

        while (i <= n)
        {
            double denominator = (2.0 * i) + 1.0;
            sum += sign / denominator;
            sign *= -1.0;

            i++;
        }

        return sum;
    }
}
