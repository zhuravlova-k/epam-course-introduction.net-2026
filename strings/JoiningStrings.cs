using System;
using System.Collections.Generic;

namespace Strings;

public static class JoiningStrings
{
    public static string GetCommaSeparatedString(string[] values)
    {
        ArgumentNullException.ThrowIfNull(values);
        return string.Join(",", values);
    }

    public static string GetColonSeparatedString(string[] values)
    {
        ArgumentNullException.ThrowIfNull(values);
        return string.Join(":", values);
    }

    public static string GetCommaSeparatedStringWithoutFirstElement(string[] values)
    {
        ArgumentNullException.ThrowIfNull(values);
        return string.Join(",", values, 1, values.Length - 1);
    }

    public static string GetHyphenSeparatedStringWithoutFirstAndLastElements(string[] values)
    {
        ArgumentNullException.ThrowIfNull(values);
        return string.Join("-", values, 1, values.Length - 2);
    }

    public static string GetPlusSeparatedString(IEnumerable<string> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        return string.Join("+", values);
    }

    public static string GetBackslashSeparatedString(IEnumerable<object> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        return string.Join("\\", values);
    }

    public static string GetStringSeparatedString(object[] values)
    {
        ArgumentNullException.ThrowIfNull(values);
        return string.Join("], [", values);
    }

    public static string GetStringSeparatedStringForLastThreeElements(string separator, string[] values)
    {
        ArgumentNullException.ThrowIfNull(separator);
        ArgumentNullException.ThrowIfNull(values);
        return string.Join(separator, values, values.Length - 3, 3);
    }
}
