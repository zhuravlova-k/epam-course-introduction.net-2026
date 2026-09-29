using System;

namespace BookStoreCatalog;

public class NameIdentifier
{
    public NameIdentifier(string isniCode)
    {
        ArgumentNullException.ThrowIfNull(isniCode);

        if (!ValidateCode(isniCode))
        {
            throw new ArgumentException("The ISNI code must be exactly 16 characters long and contain only digits or 'X'.", nameof(isniCode));
        }

        this.Code = isniCode;
    }

    public string Code { get; init; } = null!;

    public Uri GetUri()
    {
        return new Uri($"https://isni.org/isni/{this.Code}");
    }

    public override string ToString()
    {
        return this.Code;
    }

    private static bool ValidateCode(string isniCode)
    {
        if (isniCode.Length != 16)
        {
            return false;
        }

        foreach (char c in isniCode)
        {
            if (!char.IsDigit(c) && c != 'X')
            {
                return false;
            }
        }

        return true;
    }
}
