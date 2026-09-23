using System;
using FilterByPredicate;

namespace FilterByDigit;

/// <summary>
/// Predicate that determines the presence of some digit in integer.
/// </summary>
public class ByDigitPredicate : IPredicate
{
    private int digit;

    /// <summary>
    /// Gets or sets a digit.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when Digit more than 9 or less than 0.</exception>
    public int Digit
    {
        get => this.digit;
        set
        {
            if (value < 0 || value > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Digit must be between 0 and 9.");
            }

            this.digit = value;
        }
    }

    /// <inheritdoc/>
    public bool IsMatch(int number)
    {
        if (number == 0 && this.Digit == 0)
        {
            return true;
        }

        long currentNumber = Math.Abs((long)number);

        while (currentNumber > 0)
        {
            long currentDigit = currentNumber % 10;

            if (currentDigit == this.Digit)
            {
                return true;
            }

            currentNumber /= 10;
        }

        return false;
    }
}
