using System;

namespace PopulationTask
{
    public static class Population
    {
        public static int GetYears(int initialPopulation, double percent, int visitors, int currentPopulation)
        {
            if (initialPopulation <= 0)
            {
                throw new ArgumentException("Initial population cannot be less or equal to zero.");
            }

            if (visitors < 0)
            {
                throw new ArgumentException("Visitors cannot be less than zero.");
            }

            if (currentPopulation <= 0)
            {
                throw new ArgumentException("Current population cannot be less or equal to zero.");
            }

            if (currentPopulation < initialPopulation)
            {
                throw new ArgumentException("Current population cannot be less than initial population.");
            }

            if (percent < 0 || percent > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percent), "Percent should be between 0 and 100.");
            }

            int years = 0;

            while (initialPopulation < currentPopulation)
            {
                initialPopulation += (int)(initialPopulation * (percent / 100.0)) + visitors;
                years++;
            }

            return years;
        }
    }
}
