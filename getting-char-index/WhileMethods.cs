namespace GettingCharIndex;

public static class WhileMethods
{
    public static int GetIndexOfChar(string? str, char value)
    {
        ArgumentNullException.ThrowIfNull(str);

        int currentCharIndex = 0;
        while (currentCharIndex < str.Length)
        {
            char currentChar = str[currentCharIndex];
            if (currentChar == value)
            {
                return currentCharIndex;
            }

            currentCharIndex++;
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

        int currentCharIndex = startIndex;
        int limit = startIndex + count;

        while (currentCharIndex < limit)
        {
            char currentChar = str[currentCharIndex];
            if (currentChar == value)
            {
                return currentCharIndex;
            }

            currentCharIndex++;
        }

        return -1;
    }

    public static int GetLastIndexOfChar(string? str, char value)
    {
        ArgumentNullException.ThrowIfNull(str);

        int currentCharIndex = str.Length - 1;
        while (currentCharIndex >= 0)
        {
            char currentChar = str[currentCharIndex];
            if (currentChar == value)
            {
                return currentCharIndex;
            }

            currentCharIndex--;
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

        int currentCharIndex = startIndex + count - 1;
        while (currentCharIndex >= startIndex)
        {
            char currentChar = str[currentCharIndex];
            if (currentChar == value)
            {
                return currentCharIndex;
            }

            currentCharIndex--;
        }

        return -1;
    }
}
