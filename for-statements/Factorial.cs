namespace ForStatements;

public static class Factorial
{
    public static int GetFactorial(int n)
    {
        int result = 1;

        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    public static int SumFactorialDigits(int n)
    {
        int factorial = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }

        int sum = 0;

        for (; factorial > 0; factorial /= 10)
        {
            sum += factorial % 10;
        }

        return sum;
    }
}
