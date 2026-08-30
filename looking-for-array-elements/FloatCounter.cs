namespace LookingForArrayElements;

public static class FloatCounter
{
    private static void CheckRanges(float[] rangeStart, float[] rangeEnd)
    {
        if (rangeStart.Length != rangeEnd.Length)
        {
            throw new ArgumentException("rangeStart and rangeEnd must have the same number of elements.");
        }

        for (int i = 0; i < rangeStart.Length; i++)
        {
            if (rangeStart[i] > rangeEnd[i])
            {
                throw new ArgumentException("range start value cannot be greater than range end value.");
            }
        }
    }

    public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd)
    {
        ArgumentNullException.ThrowIfNull(arrayToSearch);
        ArgumentNullException.ThrowIfNull(rangeStart);
        ArgumentNullException.ThrowIfNull(rangeEnd);

        CheckRanges(rangeStart, rangeEnd);

        int matchCount = 0;

        for (int i = 0; i < arrayToSearch.Length; i++)
        {
            float currentValue = arrayToSearch[i];

            for (int j = 0; j < rangeStart.Length; j++)
            {
                if (currentValue >= rangeStart[j] && currentValue <= rangeEnd[j])
                {
                    matchCount++;
                    break;
                }
            }
        }

        return matchCount;
    }

    public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd, int startIndex, int count)
    {
        ArgumentNullException.ThrowIfNull(arrayToSearch);
        ArgumentNullException.ThrowIfNull(rangeStart);
        ArgumentNullException.ThrowIfNull(rangeEnd);

        CheckRanges(rangeStart, rangeEnd);

        if (startIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
        }

        if (startIndex > arrayToSearch.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than arrayToSearch.Length");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
        }

        int endIndex = startIndex + count;
        if (endIndex > arrayToSearch.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > arrayToSearch.Length");
        }

        if (count == 0 || rangeStart.Length == 0)
        {
            return 0;
        }

        int matchCount = 0;
        int i = startIndex;

        do
        {
            float currentValue = arrayToSearch[i];
            int j = 0;

            do
            {
                if (currentValue >= rangeStart[j] && currentValue <= rangeEnd[j])
                {
                    matchCount++;
                    break;
                }
                j++;
            }
            while (j < rangeStart.Length);

            i++;
        }
        while (i < endIndex);

        return matchCount;
    }
}
