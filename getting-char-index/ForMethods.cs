namespace GettingCharIndex;

public static class ForMethods
{
    public static int GetIndexOfChar(string? str, char value)
    {
        ArgumentNullException.ThrowIfNull(str);

        for (int currentCharIndex = 0; currentCharIndex < str.Length; currentCharIndex++)
        {
            char currentChar = str[currentCharIndex];
            if (currentChar == value)
            {
                return currentCharIndex;
            }
        }

        return -1;
    }

    public static int GetIndexOfChar(string? str, char value, int startIndex, int count)
    {
        ArgumentNullException.ThrowIfNull(str);

        if (startIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
        }

        if (startIndex > str.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than str.Length");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
        }

        if (startIndex + count > str.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > str.Length");
        }

        int limit = startIndex + count;
        for (int currentCharIndex = startIndex; currentCharIndex < limit; currentCharIndex++)
        {
            char currentChar = str[currentCharIndex];
            if (currentChar == value)
            {
                return currentCharIndex;
            }
        }

        return -1;
    }

    public static int GetLastIndexOfChar(string? str, char value)
    {
        ArgumentNullException.ThrowIfNull(str);

        for (int currentCharIndex = str.Length - 1; currentCharIndex >= 0; currentCharIndex--)
        {
            char currentChar = str[currentCharIndex];
            if (currentChar == value)
            {
                return currentCharIndex;
            }
        }

        return -1;
    }

    public static int GetLastIndexOfChar(string? str, char value, int startIndex, int count)
    {
        ArgumentNullException.ThrowIfNull(str);

        if (startIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
        }

        if (startIndex > str.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than str.Length");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
        }

        if (startIndex + count > str.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > str.Length");
        }

        for (int currentCharIndex = startIndex + count - 1; currentCharIndex >= startIndex; currentCharIndex--)
        {
            char currentChar = str[currentCharIndex];
            if (currentChar == value)
            {
                return currentCharIndex;
            }
        }

        return -1;
    }
}
