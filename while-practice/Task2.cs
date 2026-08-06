namespace WhilePractice;

public static class Task2
{
    public static double SumSequenceElements(int n)
    {
        double sum = 0.0;
        int i = 1;
        double sign = 1.0;

        while (i <= n)
        {
            sum += sign / (i * (i + 1.0));
            sign *= -1.0;
            i++;
        }

        return sum;
    }
}
