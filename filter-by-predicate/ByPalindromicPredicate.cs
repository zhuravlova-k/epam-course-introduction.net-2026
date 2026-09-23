using System;
using FilterByPredicate;

namespace FilterByPalindromic;

/// <summary>
/// Palindrome predicate.
/// </summary>
public class ByPalindromicPredicate : IPredicate
{
    /// <inheritdoc/>
    public bool IsMatch(int number)
    {
        if (number < 0)
        {
            return false;
        }

        long currentNumber = number;
        long reversedNumber = 0;

        while (currentNumber > 0)
        {
            long digit = currentNumber % 10;
            reversedNumber = (reversedNumber * 10) + digit;
            currentNumber /= 10;
        }

        return number == reversedNumber;
    }
}
