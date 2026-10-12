using System;
using GenericMethods.Interfaces;

namespace IntegerPredicate
{
    public class ContainsDigitPredicate : IPredicate<int>
    {
        public int Digit { get; set; }

        public bool IsMatch(int obj)
        {
            if (obj == 0)
            {
                if (this.Digit == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            long number = Math.Abs((long)obj);
            long targetDigit = Math.Abs((long)this.Digit);

            while (number > 0)
            {
                long currentDigit = number % 10;

                if (currentDigit == targetDigit)
                {
                    return true;
                }

                number = number / 10;
            }

            return false;
        }
    }
}
