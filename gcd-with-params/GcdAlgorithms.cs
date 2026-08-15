using System;
using System.Diagnostics;

namespace Gcd;

public static class GcdAlgorithms
{
    public static int GetGcdByEuclidean(int first, int second)
    {
        if (first == int.MinValue || second == int.MinValue)
        {
            throw new ArgumentOutOfRangeException(nameof(first), "numbers cannot be int.MinValue");
        }

        if (first == 0 && second == 0)
        {
            throw new ArgumentException("all numbers are 0 at the same time");
        }

        return MathEuclidean(first, second);
    }

    public static int GetGcdByEuclidean(int first, int second, int third)
    {
        if (first == int.MinValue || second == int.MinValue || third == int.MinValue)
        {
            throw new ArgumentOutOfRangeException(nameof(first), "numbers cannot be int.MinValue");
        }

        if (first == 0 && second == 0 && third == 0)
        {
            throw new ArgumentException("all numbers are 0 at the same time");
        }

        int tempGcd = MathEuclidean(first, second);
        return MathEuclidean(tempGcd, third);
    }

    public static int GetGcdByEuclidean(int first, int second, params int[] numbers)
    {
        if (first == int.MinValue || second == int.MinValue)
        {
            throw new ArgumentOutOfRangeException(nameof(first), "numbers cannot be int.MinValue");
        }

        bool allZeros = first == 0 && second == 0;

        if (numbers != null)
        {
            foreach (int n in numbers)
            {
                if (n == int.MinValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(first), "numbers cannot be int.MinValue");
                }

                if (n != 0)
                {
                    allZeros = false;
                }
            }
        }

        if (allZeros)
        {
            throw new ArgumentException("all numbers are 0 at the same time");
        }

        int result = MathEuclidean(first, second);

        if (numbers != null)
        {
            foreach (int n in numbers)
            {
                result = MathEuclidean(result, n);
            }
        }

        return result;
    }

    public static int GetGcdByEuclidean(out long milliseconds, int first, int second)
    {
        Stopwatch timer = Stopwatch.StartNew();
        int result = GetGcdByEuclidean(first, second);
        timer.Stop();

        long ms = timer.ElapsedMilliseconds;
        milliseconds = ms == 0 ? 1 : ms;
        return result;
    }

    public static int GetGcdByEuclidean(out long milliseconds, int first, int second, int third)
    {
        Stopwatch timer = Stopwatch.StartNew();
        int result = GetGcdByEuclidean(first, second, third);
        timer.Stop();

        long ms = timer.ElapsedMilliseconds;
        milliseconds = ms == 0 ? 1 : ms;
        return result;
    }

    public static int GetGcdByEuclidean(out long milliseconds, int first, int second, params int[] numbers)
    {
        Stopwatch timer = Stopwatch.StartNew();
        int result = GetGcdByEuclidean(first, second, numbers);
        timer.Stop();

        long ms = timer.ElapsedMilliseconds;
        milliseconds = ms == 0 ? 1 : ms;
        return result;
    }

    public static (int gcd, long milliseconds) GetGcdByEuclideanWithTime(int first, int second)
    {
        Stopwatch timer = Stopwatch.StartNew();
        int result = GetGcdByEuclidean(first, second);
        timer.Stop();

        long ms = timer.ElapsedMilliseconds;
        return (result, ms == 0 ? 1 : ms);
    }

    public static (int gcd, long milliseconds) GetGcdByEuclideanWithTime(int first, int second, int third)
    {
        Stopwatch timer = Stopwatch.StartNew();
        int result = GetGcdByEuclidean(first, second, third);
        timer.Stop();

        long ms = timer.ElapsedMilliseconds;
        return (result, ms == 0 ? 1 : ms);
    }

    public static (int gcd, long milliseconds) GetGcdByEuclideanWithTime(int first, int second, params int[] numbers)
    {
        Stopwatch timer = Stopwatch.StartNew();
        int result = GetGcdByEuclidean(first, second, numbers);
        timer.Stop();

        long ms = timer.ElapsedMilliseconds;
        return (result, ms == 0 ? 1 : ms);
    }

    public static int GetGcdByStein(int first, int second)
    {
        if (first == int.MinValue || second == int.MinValue)
        {
            throw new ArgumentOutOfRangeException(nameof(first), "numbers cannot be int.MinValue");
        }

        if (first == 0 && second == 0)
        {
            throw new ArgumentException("all numbers are 0 at the same time");
        }

        return MathStein(first, second);
    }

    public static int GetGcdByStein(int first, int second, int third)
    {
        if (first == int.MinValue || second == int.MinValue || third == int.MinValue)
        {
            throw new ArgumentOutOfRangeException(nameof(first), "numbers cannot be int.MinValue");
        }

        if (first == 0 && second == 0 && third == 0)
        {
            throw new ArgumentException("all numbers are 0 at the same time");
        }

        int tempGcd = MathStein(first, second);
        return MathStein(tempGcd, third);
    }

    public static int GetGcdByStein(int first, int second, params int[] numbers)
    {
        if (first == int.MinValue || second == int.MinValue)
        {
            throw new ArgumentOutOfRangeException(nameof(first), "numbers cannot be int.MinValue");
        }

        bool allZeros = first == 0 && second == 0;

        if (numbers != null)
        {
            foreach (int n in numbers)
            {
                if (n == int.MinValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(first), "numbers cannot be int.MinValue");
                }

                if (n != 0)
                {
                    allZeros = false;
                }
            }
        }

        if (allZeros)
        {
            throw new ArgumentException("all numbers are 0 at the same time");
        }

        int result = MathStein(first, second);

        if (numbers != null)
        {
            foreach (int n in numbers)
            {
                result = MathStein(result, n);
            }
        }

        return result;
    }

    public static int GetGcdByStein(out long milliseconds, int first, int second)
    {
        Stopwatch timer = Stopwatch.StartNew();
        int result = GetGcdByStein(first, second);
        timer.Stop();

        long ms = timer.ElapsedMilliseconds;
        milliseconds = ms == 0 ? 1 : ms;
        return result;
    }

    public static int GetGcdByStein(out long milliseconds, int first, int second, int third)
    {
        Stopwatch timer = Stopwatch.StartNew();
        int result = GetGcdByStein(first, second, third);
        timer.Stop();

        long ms = timer.ElapsedMilliseconds;
        milliseconds = ms == 0 ? 1 : ms;
        return result;
    }

    public static int GetGcdByStein(out long milliseconds, int first, int second, params int[] numbers)
    {
        Stopwatch timer = Stopwatch.StartNew();
        int result = GetGcdByStein(first, second, numbers);
        timer.Stop();

        long ms = timer.ElapsedMilliseconds;
        milliseconds = ms == 0 ? 1 : ms;
        return result;
    }

    public static (int gcd, long milliseconds) GetGcdBySteinWithTime(int first, int second)
    {
        Stopwatch timer = Stopwatch.StartNew();
        int result = GetGcdByStein(first, second);
        timer.Stop();

        long ms = timer.ElapsedMilliseconds;
        return (result, ms == 0 ? 1 : ms);
    }

    public static (int gcd, long milliseconds) GetGcdBySteinWithTime(int first, int second, int third)
    {
        Stopwatch timer = Stopwatch.StartNew();
        int result = GetGcdByStein(first, second, third);
        timer.Stop();

        long ms = timer.ElapsedMilliseconds;
        return (result, ms == 0 ? 1 : ms);
    }

    public static (int gcd, long milliseconds) GetGcdBySteinWithTime(int first, int second, params int[] numbers)
    {
        Stopwatch timer = Stopwatch.StartNew();
        int result = GetGcdByStein(first, second, numbers);
        timer.Stop();

        long ms = timer.ElapsedMilliseconds;
        return (result, ms == 0 ? 1 : ms);
    }

    private static int MathEuclidean(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    private static int MathStein(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        if (a == 0)
        {
            return b;
        }

        if (b == 0)
        {
            return a;
        }

        int shift;
        for (shift = 0; ((a | b) & 1) == 0; ++shift)
        {
            a >>= 1;
            b >>= 1;
        }

        while ((a & 1) == 0)
        {
            a >>= 1;
        }

        do
        {
            while ((b & 1) == 0)
            {
                b >>= 1;
            }

            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            b -= a;
        }
        while (b != 0);

        return a << shift;
    }
}
