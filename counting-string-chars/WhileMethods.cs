using System;

namespace CountingStringChars;

public static class WhileMethods
{
    public static int GetSpaceCount(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        int count = 0;
        int i = 0;

        while (i < str.Length)
        {
            if (char.IsWhiteSpace(str[i]))
            {
                count++;
            }

            i++;
        }

        return count;
    }

    public static int GetPunctuationCount(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        int count = 0;
        int i = 0;

        while (i < str.Length)
        {
            if (char.IsPunctuation(str[i]))
            {
                count++;
            }

            i++;
        }

        return count;
    }

    public static int GetSpaceCountRecursive(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        if (string.IsNullOrEmpty(str))
        {
            return 0;
        }

        int result = GetSpaceCountRecursive(str[1..]) + (char.IsWhiteSpace(str[0]) ? 1 : 0);

        return result;
    }

    public static int GetPunctuationCountRecursive(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        if (string.IsNullOrEmpty(str))
        {
            return 0;
        }

        bool isPunctuation = char.IsPunctuation(str[0]);
        int currentIncrement = isPunctuation ? 1 : 0;
        int result = GetPunctuationCountRecursive(str[1..]) + currentIncrement;

        return result;
    }
}
