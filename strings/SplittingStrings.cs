using System;

namespace Strings;

public static class SplittingStrings
{
    private static readonly char[] ColonAndCommaSeparators = { ':', ',' };
    private static readonly char[] WordSeparators = { ' ', '.', ',', '!', '?', ':', ';', '-', '\t' };

    public static string[] SplitCommaSeparatedString(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str.Split(',');
    }

    public static string[] SplitColonSeparatedString(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str.Split(':');
    }

    public static string[] SplitCommaSeparatedStringMaxTwoElements(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str.Split(',', 2);
    }

    public static string[] SplitColonSeparatedStringMaxThreeElements(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str.Split(':', 3);
    }

    public static string[] SplitHyphenSeparatedStringMaxThreeElementsRemoveEmptyStrings(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str.Split('-', 3, StringSplitOptions.RemoveEmptyEntries);
    }

    public static string[] SplitColonAndCommaSeparatedStringMaxFourElementsRemoveEmptyStrings(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str.Split(ColonAndCommaSeparators, 4, StringSplitOptions.RemoveEmptyEntries);
    }

    public static string[] GetOnlyWords(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
    }

    public static string[] GetDataFromCsvLine(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str.Split(',', StringSplitOptions.TrimEntries);
    }
}
