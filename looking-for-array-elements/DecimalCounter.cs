namespace LookingForArrayElements;

public static class DecimalCounter
{
    private static void CheckRanges(decimal[]?[] ranges)
    {
        for (int i = 0; i < ranges.Length; i++)
        {
            if (ranges[i] == null)
            {
                throw new ArgumentNullException(nameof(ranges), "range array cannot contain null elements.");
            }

            if (ranges[i]!.Length != 0 && ranges[i]!.Length != 2)
            {
                throw new ArgumentException("range array must contain exactly two elements.", nameof(ranges));
            }
        }
    }

    public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges)
    {
        ArgumentNullException.ThrowIfNull(arrayToSearch);
        ArgumentNullException.ThrowIfNull(ranges);

        CheckRanges(ranges);

        if (arrayToSearch.Length == 0 || ranges.Length == 0)
        {
            return 0;
        }

        int matchCount = 0;
        int i = 0;

        do
        {
            decimal currentValue = arrayToSearch[i];
            int j = 0;

            do
            {
                if (ranges[j]!.Length == 2 && currentValue >= ranges[j]![0] && currentValue <= ranges[j]![1])
                {
                    matchCount++;
                    break;
                }
                j++;
            }
            while (j < ranges.Length);

            i++;
        }
        while (i < arrayToSearch.Length);

        return matchCount;
    }

    public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges, int startIndex, int count)
    {
        ArgumentNullException.ThrowIfNull(arrayToSearch);
        ArgumentNullException.ThrowIfNull(ranges);

        CheckRanges(ranges);

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

        int matchCount = 0;

        for (int i = startIndex; i < endIndex; i++)
        {
            decimal currentValue = arrayToSearch[i];

            for (int j = 0; j < ranges.Length; j++)
            {
                if (ranges[j]!.Length == 2 && currentValue >= ranges[j]![0] && currentValue <= ranges[j]![1])
                {
                    matchCount++;
                    break;
                }
            }
        }

        return matchCount;
    }
}
