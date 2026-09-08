using System;

namespace LookingForChars;

public static class CharsCounter
{
    public static int GetCharsCount(string? str, char[]? chars)
    {
        ArgumentNullException.ThrowIfNull(str);
        ArgumentNullException.ThrowIfNull(chars);

        int count = 0;
        for (int i = 0; i < str.Length; i++)
        {
            for (int j = 0; j < chars.Length; j++)
            {
                if (str[i] == chars[j])
                {
                    count++;
                    break;
                }
            }
        }

        return count;
    }

    public static int GetCharsCount(string? str, char[]? chars, int startIndex, int endIndex)
    {
        ArgumentNullException.ThrowIfNull(str);
        ArgumentNullException.ThrowIfNull(chars);

        if (startIndex < 0 || startIndex > str.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if (endIndex < 0 || endIndex >= str.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(endIndex));
        }

        if (startIndex <= endIndex)
        {
            int count = 0;
            int i = startIndex;

            while (i <= endIndex)
            {
                int j = 0;
                while (j < chars.Length)
                {
                    if (str[i] == chars[j])
                    {
                        count++;
                        break;
                    }

                    j++;
                }

                i++;
            }

            return count;
        }

        throw new ArgumentOutOfRangeException(nameof(startIndex));
    }

    public static int GetCharsCount(string? str, char[]? chars, int startIndex, int endIndex, int limit)
    {
        ArgumentNullException.ThrowIfNull(str);
        ArgumentNullException.ThrowIfNull(chars);

        if (startIndex < 0 || startIndex > str.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if (endIndex < 0 || endIndex >= str.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(endIndex));
        }

        ArgumentOutOfRangeException.ThrowIfGreaterThan(startIndex, endIndex);

        if (limit >= 0)
        {
            if (limit == 0 || chars.Length == 0)
            {
                return 0;
            }

            int count = 0;
            int i = startIndex;

            do
            {
                int j = 0;
                do
                {
                    if (str[i] == chars[j])
                    {
                        count++;
                        break;
                    }

                    j++;
                }
                while (j < chars.Length);

                if (count >= limit)
                {
                    break;
                }

                i++;
            }
            while (i <= endIndex);

            return count;
        }

        throw new ArgumentOutOfRangeException(nameof(limit));
    }
}
