using System;
using System.Globalization;

namespace LouVuiDateCode;

public static class DateCodeParser
{
    public static void ParseEarly1980Code(string dateCode, out uint manufacturingYear, out uint manufacturingMonth)
    {
        if (string.IsNullOrEmpty(dateCode))
        {
            throw new ArgumentNullException(nameof(dateCode));
        }

        if (dateCode.Length < 3 || dateCode.Length > 4 || !uint.TryParse(dateCode, out _))
        {
            throw new ArgumentException("Invalid date code format.", nameof(dateCode));
        }

        uint yearPart = uint.Parse(dateCode.AsSpan(0, 2), CultureInfo.InvariantCulture);
        manufacturingYear = 1900 + yearPart;

        manufacturingMonth = uint.Parse(dateCode.AsSpan(2), CultureInfo.InvariantCulture);

        if (manufacturingYear < 1980 || manufacturingYear > 1989 || manufacturingMonth < 1 || manufacturingMonth > 12)
        {
            throw new ArgumentException("Date is out of range for early 1980s.", nameof(dateCode));
        }
    }

    public static void ParseLate1980Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
    {
        if (string.IsNullOrEmpty(dateCode))
        {
            throw new ArgumentNullException(nameof(dateCode));
        }

        if (dateCode.Length < 5 || dateCode.Length > 6)
        {
            throw new ArgumentException("Invalid date code format.", nameof(dateCode));
        }

        factoryLocationCode = dateCode.Substring(dateCode.Length - 2);
        factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);

        string digits = dateCode.Substring(0, dateCode.Length - 2);

        if (!uint.TryParse(digits, out _))
        {
            throw new ArgumentException("Invalid date digits.", nameof(dateCode));
        }

        uint yearPart = uint.Parse(digits.AsSpan(0, 2), CultureInfo.InvariantCulture);
        manufacturingYear = 1900 + yearPart;

        manufacturingMonth = uint.Parse(digits.AsSpan(2), CultureInfo.InvariantCulture);

        if (manufacturingYear < 1980 || manufacturingYear > 1989 || manufacturingMonth < 1 || manufacturingMonth > 12)
        {
            throw new ArgumentException("Date is out of range for late 1980s.", nameof(dateCode));
        }
    }

    public static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
    {
        if (string.IsNullOrEmpty(dateCode))
        {
            throw new ArgumentNullException(nameof(dateCode));
        }

        if (dateCode.Length != 6)
        {
            throw new ArgumentException("Invalid date code format.", nameof(dateCode));
        }

        factoryLocationCode = dateCode.Substring(0, 2);
        string digits = dateCode.Substring(2, 4);

        if (!uint.TryParse(digits, out _))
        {
            throw new ArgumentException("Invalid date digits.", nameof(dateCode));
        }

        factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);

        uint m1 = (uint)char.GetNumericValue(digits[0]);
        uint y1 = (uint)char.GetNumericValue(digits[1]);
        uint m2 = (uint)char.GetNumericValue(digits[2]);
        uint y2 = (uint)char.GetNumericValue(digits[3]);

        manufacturingMonth = (m1 * 10) + m2;
        uint yearPart = (y1 * 10) + y2;

        manufacturingYear = yearPart >= 90 ? 1900 + yearPart : 2000 + yearPart;

        if (manufacturingYear < 1990 || manufacturingYear > 2006 || manufacturingMonth < 1 || manufacturingMonth > 12)
        {
            throw new ArgumentException("Date is out of range for 1990-2006.", nameof(dateCode));
        }
    }

    public static void Parse2007Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingWeek)
    {
        if (string.IsNullOrEmpty(dateCode))
        {
            throw new ArgumentNullException(nameof(dateCode));
        }

        if (dateCode.Length != 6)
        {
            throw new ArgumentException("Invalid date code format.", nameof(dateCode));
        }

        factoryLocationCode = dateCode.Substring(0, 2);
        string digits = dateCode.Substring(2, 4);

        if (!uint.TryParse(digits, out _))
        {
            throw new ArgumentException("Invalid date digits.", nameof(dateCode));
        }

        factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);

        uint w1 = (uint)char.GetNumericValue(digits[0]);
        uint y1 = (uint)char.GetNumericValue(digits[1]);
        uint w2 = (uint)char.GetNumericValue(digits[2]);
        uint y2 = (uint)char.GetNumericValue(digits[3]);

        manufacturingWeek = (w1 * 10) + w2;
        manufacturingYear = 2000 + (y1 * 10) + y2;

        if (manufacturingYear < 2007)
        {
            throw new ArgumentException("Year is out of range for post 2007.", nameof(dateCode));
        }

        int maxWeeks = ISOWeek.GetWeeksInYear((int)manufacturingYear);
        if (manufacturingWeek < 1 || manufacturingWeek > maxWeeks)
        {
            throw new ArgumentException("Invalid week number.", nameof(dateCode));
        }
    }
}
