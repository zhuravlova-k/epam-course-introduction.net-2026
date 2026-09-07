using System;

namespace CountingStringChars;

public static class DoWhileMethods
{
    public static int GetDigitCount(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        if (str.Length == 0)
        {
            return 0;
        }

        int count = 0;
        int i = 0;

        do
        {
            if (char.IsDigit(str[i]))
            {
                count++;
            }

            i++;
        }
        while (i < str.Length);

        return count;
    }

    public static int GetLetterCount(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        if (str.Length == 0)
        {
            return 0;
        }

        int count = 0;
        int i = 0;

        do
        {
            if (char.IsLetter(str[i]))
            {
                count++;
            }

            i++;
        }
        while (i < str.Length);

        return count;
    }

    public static int GetDigitCountRecursive(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        return GetDigitCountRecursive(str, str.Length, 0);
    }

    public static int GetLetterCountRecursive(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        return GetLetterCountRecursive(str, str.Length, 0);
    }

    private static int GetDigitCountRecursive(string str, int charsLeft, int counter)
    {
        if (charsLeft > 0)
        {
            return GetDigitCountRecursive(str, charsLeft - 1, char.IsDigit(str[^charsLeft]) ? counter + 1 : counter);
        }

        return counter;
    }

    private static int GetLetterCountRecursive(string str, int charsLeft, int counter)
    {
        if (charsLeft > 0)
        {
            return GetLetterCountRecursive(str, charsLeft - 1, char.IsLetter(str[^charsLeft]) ? counter + 1 : counter);
        }

        return counter;
    }
}
