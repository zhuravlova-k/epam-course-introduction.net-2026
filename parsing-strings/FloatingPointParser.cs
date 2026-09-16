using System;
using System.Globalization;

namespace ParsingStrings;

public static class FloatingPointParser
{
    public static bool TryParseFloat(string? str, out float result)
    {
        return float.TryParse(str, out result);
    }

    public static float ParseFloat(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        try
        {
            return float.Parse(str, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            return float.NaN;
        }
        catch (OverflowException)
        {
            return float.NaN;
        }
    }

    public static bool TryParseDouble(string? str, out double result)
    {
        return double.TryParse(str, out result);
    }

    public static double ParseDouble(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        try
        {
            return double.Parse(str, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            return double.Epsilon;
        }
        catch (OverflowException)
        {
            return double.Epsilon;
        }
    }

    public static bool TryParseDecimal(string? str, out decimal result)
    {
        return decimal.TryParse(str, out result);
    }

    public static decimal ParseDecimal(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        try
        {
            return decimal.Parse(str, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            return -1.1m;
        }
        catch (OverflowException)
        {
            return -2.2m;
        }
    }
}
