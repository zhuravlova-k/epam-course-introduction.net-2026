using System;
using System.Collections.Generic;

namespace JosephusProblem
{
    public static class JosephusFlavius
    {
        public static IEnumerable<int> GetCrossedOutPersons(int count, int crossedOut)
        {
            if (count < 1)
            {
                throw new ArgumentException($"{count} must be greater than 0.", nameof(count));
            }

            if (crossedOut < 1)
            {
                throw new ArgumentException($"{crossedOut} must be greater than 0.", nameof(crossedOut));
            }

            return GetCrossedOutPersonsIterator(count, crossedOut);
        }

        public static int GetSurvivor(int count, int crossedOut)
        {
            if (count < 1)
            {
                throw new ArgumentException($"{count} must be greater than 0.", nameof(count));
            }

            if (crossedOut < 1)
            {
                throw new ArgumentException($"{crossedOut} must be greater than 0.", nameof(crossedOut));
            }

            int survivor = 0;

            for (int i = 2; i <= count; i++)
            {
                survivor = (survivor + crossedOut) % i;
            }

            return survivor + 1;
        }

        private static IEnumerable<int> GetCrossedOutPersonsIterator(int count, int crossedOut)
        {
            int[] next = new int[count + 1];
            for (int i = 1; i < count; i++)
            {
                next[i] = i + 1;
            }

            next[count] = 1;

            int prev = count;
            int curr = 1;

            for (int i = 0; i < count - 1; i++)
            {
                int remaining = count - i;

                int steps = (crossedOut - 1) % remaining;

                for (int j = 0; j < steps; j++)
                {
                    prev = curr;
                    curr = next[curr];
                }

                yield return curr;

                next[prev] = next[curr];
                curr = next[curr];
            }
        }
    }
}
