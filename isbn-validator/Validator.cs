using System;

namespace IsbnValidator;

public static class Validator
{
    public static bool IsIsbnValid(string isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn))
        {
            throw new ArgumentException("The ISBN cannot be empty or contain only white-space characters.", nameof(isbn));
        }

        int checksum = 0;
        int weight = 10;
        int count = 0;
        bool lastWasSeparator = false;

        for (int i = 0; i < isbn.Length; i++)
        {
            char c = isbn[i];

            if (c == '-' || c == ' ')
            {
                if (count != 1 && count != 4 && count != 9)
                {
                    return false;
                }

                if (lastWasSeparator)
                {
                    return false;
                }

                lastWasSeparator = true;
                continue;
            }

            lastWasSeparator = false;

            if (count < 9)
            {
                if (char.IsDigit(c))
                {
                    checksum += (c - '0') * weight;
                    weight--;
                    count++;
                }
                else
                {
                    return false;
                }
            }
            else if (count == 9)
            {
                if (char.IsDigit(c))
                {
                    checksum += (c - '0') * weight;
                    weight--;
                    count++;
                }
                else if (c == 'X' || c == 'x')
                {
                    checksum += 10 * weight;
                    weight--;
                    count++;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        return count == 10 && checksum % 11 == 0;
    }
}
