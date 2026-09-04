using System;

namespace Strings;

public static class CopyingStrings
{
    public static string CopyOneChar(string source, string destination)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(destination);

        char[] destArray = destination.ToCharArray();
        source.CopyTo(0, destArray, 4, 1);
        return new string(destArray);
    }

    public static string CopyThreeChars(string source, string destination)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(destination);

        char[] destArray = destination.ToCharArray();
        source.CopyTo(0, destArray, 0, 3);
        return new string(destArray);
    }

    public static string CopyFiveChars(string source, string destination)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(destination);

        char[] destArray = destination.ToCharArray();
        source.CopyTo(0, destArray, 4, 5);
        return new string(destArray);
    }

    public static string CopySixChars(string source, string destination)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(destination);

        char[] destArray = destination.ToCharArray();
        source.CopyTo(2, destArray, 5, 6);
        return new string(destArray);
    }

    public static string GetProductionCode(string template, string regionCode, string locationCode, string dateCode, string factoryCode)
    {
        ArgumentNullException.ThrowIfNull(template);
        ArgumentNullException.ThrowIfNull(regionCode);
        ArgumentNullException.ThrowIfNull(locationCode);
        ArgumentNullException.ThrowIfNull(dateCode);
        ArgumentNullException.ThrowIfNull(factoryCode);

        char[] destArray = template.ToCharArray();

        regionCode.CopyTo(1, destArray, 0, 1);
        locationCode.CopyTo(4, destArray, 3, 2);
        dateCode.CopyTo(3, destArray, 7, 3);
        factoryCode.CopyTo(2, destArray, 12, 4);

        return new string(destArray);
    }
}
