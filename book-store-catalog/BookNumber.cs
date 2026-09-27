using System;

namespace BookStoreCatalog;

public class BookNumber
{
    private readonly string code;

    public BookNumber(string isbnCode)
    {
        ArgumentNullException.ThrowIfNull(isbnCode);

        if (!ValidateCode(isbnCode) || !ValidateChecksum(isbnCode))
        {
            throw new ArgumentException("The ISBN code is invalid or has a wrong checksum.", nameof(isbnCode));
        }

        this.code = isbnCode;
    }

    public string Code => this.code;

    public Uri GetSearchUri()
    {
        return new Uri($"https://isbnsearch.org/isbn/{this.code}");
    }

    public override string ToString()
    {
        return this.code;
    }

    private static bool ValidateCode(string isbnCode)
    {
        if (isbnCode.Length != 10)
        {
            return false;
        }

        foreach (char c in isbnCode)
        {
            if (!char.IsDigit(c) && c != 'X')
            {
                return false;
            }
        }

        return true;
    }

    private static bool ValidateChecksum(string isbnCode)
    {
        if (isbnCode.Length != 10)
        {
            return false;
        }

        int checksum = 0;

        for (int i = 0; i < 10; i++)
        {
            char c = isbnCode[i];
            int value = (c == 'X') ? 10 : (c - '0');
            int multiplier = 10 - i;
            checksum += value * multiplier;
        }

        return checksum % 11 == 0;
    }
}
