using System;

namespace ShiftArrayElements;

public static class Shifter
{
    public static void Shift(int[] source, int[] iterations)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(iterations);

        if (source.Length <= 1)
        {
            return;
        }

        for (int i = 0; i < iterations.Length; i++)
        {
            int numberOfShifts = iterations[i];

            for (int j = 0; j < numberOfShifts; j++)
            {
                if (i % 2 == 0)
                {
                    int firstElement = source[0];
                    Array.Copy(source, 1, source, 0, source.Length - 1);
                    source[source.Length - 1] = firstElement;
                }
                else
                {
                    int lastElement = source[source.Length - 1];
                    Array.Copy(source, 0, source, 1, source.Length - 1);
                    source[0] = lastElement;
                }
            }
        }
    }
}
