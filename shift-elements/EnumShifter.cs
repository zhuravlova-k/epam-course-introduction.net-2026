using System;

namespace ShiftArrayElements;

public static class EnumShifter
{
    public static void Shift(int[] source, Direction[] directions)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(directions);

        for (int i = 0; i < directions.Length; i++)
        {
            Direction currentDirection = directions[i];

            switch (currentDirection)
            {
                case Direction.Left:
                    {
                        if (source.Length > 1)
                        {
                            int firstElement = source[0];
                            for (int j = 0; j < source.Length - 1; j++)
                            {
                                source[j] = source[j + 1];
                            }

                            source[source.Length - 1] = firstElement;
                        }

                        break;
                    }

                case Direction.Right:
                    {
                        if (source.Length > 1)
                        {
                            int lastElement = source[source.Length - 1];
                            for (int j = source.Length - 1; j > 0; j--)
                            {
                                source[j] = source[j - 1];
                            }

                            source[0] = lastElement;
                        }

                        break;
                    }

                default:
                    throw new InvalidOperationException($"Incorrect {currentDirection} enum value.");
            }
        }
    }
}
