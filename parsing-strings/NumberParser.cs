using System;
using System.Globalization;

namespace ParsingStrings;

public static class NumberParser
{
    public static bool TryParseInteger(string? str, out int result)
    {
        return int.TryParse(str, out result);
    }

    public static int ParseInteger(string? str)
    {
        if (str is not null)
        {
            try
            {
                return int.Parse(str, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return 0;
            }
            catch (OverflowException)
            {
                return -1;
            }
        }

        throw new ArgumentNullException(nameof(str));
    }

    public static bool TryParseUnsignedInteger(string str, out uint result)
    {
        return uint.TryParse(str, out result);
    }

    public static uint ParseUnsignedInteger(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        try
        {
            return uint.Parse(str, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            return uint.MinValue;
        }
        catch (OverflowException)
        {
            return uint.MaxValue;
        }
    }

    public static bool TryParseByte(string str, out byte result)
    {
        return byte.TryParse(str, out result);
    }

    public static byte ParseByte(string? str)
    {
        if (str is not null)
        {
            try
            {
                return byte.Parse(str, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return byte.MaxValue;
            }
            catch (OverflowException)
            {
                return byte.MinValue;
            }
        }

        throw new ArgumentNullException(nameof(str));
    }

    public static bool TrySignedByte(string str, out sbyte result)
    {
        return sbyte.TryParse(str, out result);
    }

    public static sbyte ParseSignedByte(string? str)
    {
        if (str is not null)
        {
            try
            {
                return sbyte.Parse(str, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return sbyte.MaxValue;
            }
        }

        throw new ArgumentNullException(nameof(str));
    }

    public static bool TryParseShort(string str, out short result)
    {
        return short.TryParse(str, out result);
    }

    public static short ParseShort(string? str)
    {
        if (str is not null)
        {
            try
            {
                return short.Parse(str, CultureInfo.InvariantCulture);
            }
            catch (OverflowException)
            {
                return short.MaxValue;
            }
        }

        throw new ArgumentNullException(nameof(str));
    }

    public static bool TryParseUnsignedShort(string str, out ushort result)
    {
        return ushort.TryParse(str, out result);
    }

    public static ushort ParseUnsignedShort(string? str)
    {
        if (str is not null)
        {
            try
            {
                return ushort.Parse(str, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return 0;
            }
            catch (OverflowException)
            {
                return ushort.MaxValue;
            }
        }

        throw new ArgumentNullException(nameof(str));
    }

    public static bool TryParseLong(string str, out long result)
    {
        return long.TryParse(str, out result);
    }

    public static long ParseLong(string? str)
    {
        if (str is not null)
        {
            try
            {
                return long.Parse(str, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return long.MinValue;
            }
            catch (OverflowException)
            {
                return -1;
            }
        }

        throw new ArgumentNullException(nameof(str));
    }

    public static bool TryParseUnsignedLong(string str, out ulong result)
    {
        return ulong.TryParse(str, out result);
    }

    public static ulong ParseUnsignedLong(string? str)
    {
        if (str is not null)
        {
            return ulong.Parse(str, CultureInfo.InvariantCulture);
        }

        throw new ArgumentNullException(nameof(str));
    }
}
