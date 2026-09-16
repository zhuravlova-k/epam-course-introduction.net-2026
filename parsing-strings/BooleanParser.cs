using System;

namespace ParsingStrings;

public static class BooleanParser
{
    public static bool TryParseBoolean(string? str, out bool result)
    {
        return bool.TryParse(str, out result);
    }

    public static bool ParseBoolean(string? str)
    {
        if (str is not null)
        {
            try
            {
                return bool.Parse(str);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        throw new ArgumentNullException(nameof(str));
    }
}
