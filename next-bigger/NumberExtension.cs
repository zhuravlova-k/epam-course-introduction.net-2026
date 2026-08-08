namespace NextBiggerTask
{
    public static class NumberExtension
    {
        public static int NextBiggerThan(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"Source number {number} cannot be less than zero.", nameof(number));
            }

            if (number < 10)
            {
                return -1;
            }

            long temp = number;
            long prevDigit = -1;
            long pivotMultiplier = 1;
            long pivot = -1;

            while (temp > 0)
            {
                long currDigit = temp % 10;
                if (currDigit < prevDigit)
                {
                    pivot = currDigit;
                    break;
                }

                prevDigit = currDigit;
                temp /= 10;
                pivotMultiplier *= 10;
            }

            if (pivot == -1)
            {
                return -1;
            }

            long tail = number % pivotMultiplier;
            long swapDigit = -1;
            long swapMultiplier = 1;

            for (long m = 1; m < pivotMultiplier; m *= 10)
            {
                long d = (tail / m) % 10;
                if (d > pivot)
                {
                    swapDigit = d;
                    swapMultiplier = m;
                    break;
                }
            }

            long newTail = tail - (swapDigit * swapMultiplier) + (pivot * swapMultiplier);
            long reversedTail = 0;
            long tempReverse = newTail;

            for (long m = 1; m < pivotMultiplier; m *= 10)
            {
                long d = tempReverse % 10;
                reversedTail = (reversedTail * 10) + d;
                tempReverse /= 10;
            }

            long leftPart = number / (pivotMultiplier * 10);
            long result = (leftPart * pivotMultiplier * 10) + (swapDigit * pivotMultiplier) + reversedTail;

            if (result > int.MaxValue)
            {
                return -1;
            }

            return (int)result;
        }
    }
}
