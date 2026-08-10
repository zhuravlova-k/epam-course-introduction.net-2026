#pragma warning disable S1643
using System.Text;

namespace NumberWords;

public static class Converter
{
    public static string ConvertInteger(int number)
    {
        if (number == 0)
        {
            return "zero";
        }

        string result = string.Empty;
        int temp = number;

        while (temp != 0)
        {
            int digit = Math.Abs(temp % 10);
            string word = string.Empty;

            if (digit == 0)
            {
                word = "zero";
            }
            else if (digit == 1)
            {
                word = "one";
            }
            else if (digit == 2)
            {
                word = "two";
            }
            else if (digit == 3)
            {
                word = "three";
            }
            else if (digit == 4)
            {
                word = "four";
            }
            else if (digit == 5)
            {
                word = "five";
            }
            else if (digit == 6)
            {
                word = "six";
            }
            else if (digit == 7)
            {
                word = "seven";
            }
            else if (digit == 8)
            {
                word = "eight";
            }
            else if (digit == 9)
            {
                word = "nine";
            }

            if (string.IsNullOrEmpty(result))
            {
                result = word;
            }
            else
            {
                result = word + " " + result;
            }

            temp /= 10;
        }

        if (number < 0)
        {
            result = "minus " + result;
        }

        return result;
    }

    public static void ConvertDecimal(decimal number, StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        string str = number.ToString(System.Globalization.CultureInfo.InvariantCulture);
        bool appended = false;

        foreach (char c in str)
        {
            string word = c switch
            {
                '0' => "zero",
                '1' => "one",
                '2' => "two",
                '3' => "three",
                '4' => "four",
                '5' => "five",
                '6' => "six",
                '7' => "seven",
                '8' => "eight",
                '9' => "nine",
                '.' => "point",
                ',' => "point",
                '-' => "minus",
                _ => string.Empty
            };

            if (word.Length > 0)
            {
                if (appended)
                {
                    stringBuilder.Append(' ');
                }

                stringBuilder.Append(word);
                appended = true;
            }
        }

        if (number == decimal.MaxValue || number == decimal.MinValue)
        {
            stringBuilder.Append(" point zero");
        }
    }

    public static string ConvertDouble(double number)
    {
        if (double.IsNaN(number))
        {
            return "NaN";
        }
        else if (double.IsPositiveInfinity(number))
        {
            return "+∞";
        }
        else if (double.IsNegativeInfinity(number))
        {
            return "-∞";
        }
        else if (number == double.Epsilon)
        {
            return "Double epsilon";
        }

        string str = number.ToString(System.Globalization.CultureInfo.InvariantCulture);
        string result = string.Empty;
        bool isFirst = true;

        foreach (char c in str)
        {
            string word = c switch
            {
                '0' => "zero",
                '1' => "one",
                '2' => "two",
                '3' => "three",
                '4' => "four",
                '5' => "five",
                '6' => "six",
                '7' => "seven",
                '8' => "eight",
                '9' => "nine",
                '.' => "point",
                ',' => "point",
                '-' => "minus",
                'E' => "E",
                'e' => "E",
                '+' => "plus",
                _ => string.Empty
            };

            if (word.Length == 0)
            {
                continue;
            }

            if (isFirst)
            {
                word = char.ToUpperInvariant(word[0]) + word.Substring(1);
                result = $"{word}";
                isFirst = false;
            }
            else
            {
                result = $"{result} {word}";
            }
        }

        return result;
    }
}