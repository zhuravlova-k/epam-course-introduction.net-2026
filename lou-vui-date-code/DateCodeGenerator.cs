using System;
using System.Globalization;

namespace LouVuiDateCode;

public static class DateCodeGenerator
{
    public static string GenerateEarly1980Code(uint manufacturingYear, uint manufacturingMonth)
    {
        if (manufacturingYear < 1980 || manufacturingYear > 1989)
        {
            throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
        }

        if (manufacturingMonth < 1 || manufacturingMonth > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
        }

        return $"{manufacturingYear % 100}{manufacturingMonth}";
    }

    public static string GenerateEarly1980Code(DateTime manufacturingDate)
    {
        return GenerateEarly1980Code((uint)manufacturingDate.Year, (uint)manufacturingDate.Month);
    }

    public static string GenerateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
    {
        if (manufacturingYear < 1980 || manufacturingYear > 1989)
        {
            throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
        }

        if (manufacturingMonth < 1 || manufacturingMonth > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
        }

        string code = ValidateFactoryCode(factoryLocationCode);
        return $"{manufacturingYear % 100}{manufacturingMonth}{code}";
    }

    public static string GenerateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
    {
        return GenerateLate1980Code(factoryLocationCode, (uint)manufacturingDate.Year, (uint)manufacturingDate.Month);
    }

    public static string Generate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
    {
        if (manufacturingYear < 1990 || manufacturingYear > 2006)
        {
            throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
        }

        if (manufacturingMonth < 1 || manufacturingMonth > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
        }

        string code = ValidateFactoryCode(factoryLocationCode);

        uint y1 = (manufacturingYear % 100) / 10;
        uint y2 = (manufacturingYear % 100) % 10;
        uint m1 = manufacturingMonth / 10;
        uint m2 = manufacturingMonth % 10;

        return $"{code}{m1}{y1}{m2}{y2}";
    }

    public static string Generate1990Code(string factoryLocationCode, DateTime manufacturingDate)
    {
        return Generate1990Code(factoryLocationCode, (uint)manufacturingDate.Year, (uint)manufacturingDate.Month);
    }

    public static string Generate2007Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingWeek)
    {
        if (manufacturingYear >= 2007)
        {
            int maxWeeks = ISOWeek.GetWeeksInYear((int)manufacturingYear);
            if (manufacturingWeek < 1 || manufacturingWeek > maxWeeks)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingWeek));
            }

            string code = ValidateFactoryCode(factoryLocationCode);

            uint y1 = (manufacturingYear % 100) / 10;
            uint y2 = (manufacturingYear % 100) % 10;
            uint w1 = manufacturingWeek / 10;
            uint w2 = manufacturingWeek % 10;

            return $"{code}{w1}{y1}{w2}{y2}";
        }

        throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
    }

    public static string Generate2007Code(string factoryLocationCode, DateTime manufacturingDate)
    {
        int isoYear = ISOWeek.GetYear(manufacturingDate);
        if (isoYear < 2007)
        {
            throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
        }

        int isoWeek = ISOWeek.GetWeekOfYear(manufacturingDate);
        return Generate2007Code(factoryLocationCode, (uint)isoYear, (uint)isoWeek);
    }

    private static string ValidateFactoryCode(string factoryLocationCode)
    {
        if (string.IsNullOrEmpty(factoryLocationCode))
        {
            throw new ArgumentNullException(nameof(factoryLocationCode));
        }

        CountryParser.GetCountry(factoryLocationCode);

        return factoryLocationCode.ToUpperInvariant();
    }
}
