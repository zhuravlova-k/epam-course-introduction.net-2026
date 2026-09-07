using System;

namespace CountingStringChars;

public static class ForMethods
{
    public static int GetCharCount(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        int count = 0;
        for (int i = 0; i < str.Length; i++)
        {
            count++;
        }

        return count;
    }

    public static int GetUpperCharCount(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        int count = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsUpper(str[i]))
            {
                count++;
            }
        }

        return count;
    }

    public static int GetCharCountRecursive(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        return GetCharCountRecursive(str, 0);
    }

    public static int GetUpperCharCountRecursive(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        return GetUpperCharCountRecursive(str, 0);
    }

    private static int GetCharCountRecursive(string str, int index)
    {
        if (index >= str.Length)
        {
            return 0;
        }

        return GetCharCountRecursive(str, index + 1) + 1;
    }

    private static int GetUpperCharCountRecursive(string str, int index)
    {
        if (index >= str.Length)
        {
            return 0;
        }

        bool isUpper = char.IsUpper(str[index]);
        int currentIncrement = isUpper ? 1 : 0;

        return GetUpperCharCountRecursive(str, index + 1) + currentIncrement;
    }
}
