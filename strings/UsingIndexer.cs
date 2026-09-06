using System;

namespace Strings;

public static class UsingIndexer
{
    public static char GetFirstChar(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str[0];
    }

    public static char GetSecondChar(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str[1];
    }

    public static char GetThirdChar(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str[2];
    }

    public static char GetLastChar(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str[^1];
    }

    public static char GetNextToLastChar(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str[^2];
    }

    public static char GetThirdCharFromEnd(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str[^3];
    }

    public static char GetNthChar(string str, int n)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str[n - 1];
    }

    public static char GetNthCharFromEnd(string str, int n)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str[^n];
    }

    public static char GetLastCharUsingLength(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str[str.Length - 1];
    }

    public static char GetNextToLastCharUsingLength(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str[str.Length - 2];
    }

    public static char GetFifthCharFromEndUsingLength(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str[str.Length - 5];
    }

    public static char GetNthCharFromEndUsingLength(string str, int n)
    {
        ArgumentNullException.ThrowIfNull(str);
        return str[str.Length - n];
    }

    public static void GetSpecialCodes(string serialNumber, out char expectedCode1, out char expectedCode2, out char expectedCode3)
    {
        ArgumentNullException.ThrowIfNull(serialNumber);
        expectedCode1 = serialNumber[1];
        expectedCode2 = serialNumber[^8];
        expectedCode3 = serialNumber[^4];
    }
}
