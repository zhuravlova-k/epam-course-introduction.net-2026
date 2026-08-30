namespace LookingForArrayElements;

public static class IntegersCounter
{
    public static int GetIntegersCount(int[]? arrayToSearch, int[]? elementsToSearchFor)
    {
        ArgumentNullException.ThrowIfNull(arrayToSearch);
        ArgumentNullException.ThrowIfNull(elementsToSearchFor);

        int matchCount = 0;

        for (int i = 0; i < arrayToSearch.Length; i++)
        {
            int currentValue = arrayToSearch[i];

            for (int j = 0; j < elementsToSearchFor.Length; j++)
            {
                if (currentValue == elementsToSearchFor[j])
                {
                    matchCount++;
                    break;
                }
            }
        }

        return matchCount;
    }

    public static int GetIntegersCount(int[]? arrayToSearch, int[]? elementsToSearchFor, int startIndex, int count)
    {
        ArgumentNullException.ThrowIfNull(arrayToSearch);
        ArgumentNullException.ThrowIfNull(elementsToSearchFor);

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
        int i = startIndex;

        while (i < endIndex)
        {
            int currentValue = arrayToSearch[i];
            int j = 0;

            while (j < elementsToSearchFor.Length)
            {
                if (currentValue == elementsToSearchFor[j])
                {
                    matchCount++;
                    break;
                }
                j++;
            }

            i++;
        }

        return matchCount;
    }
}
