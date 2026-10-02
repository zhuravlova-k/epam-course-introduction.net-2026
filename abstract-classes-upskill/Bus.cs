using System;

namespace TollCalculator;

public class Bus : Vehicle
{
    private int capacity;
    private int passengers;

    public Bus(decimal basicToll, int capacity, int passengers)
        : base(basicToll)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");
        }

        if (passengers < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(passengers), "Passengers cannot be less than zero.");
        }

        this.capacity = capacity;
        this.passengers = passengers;
    }

    public int Capacity
    {
        get => this.capacity;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Capacity must be greater than zero.");
            }

            this.capacity = value;
        }
    }

    public int Passengers
    {
        get => this.passengers;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Passengers cannot be less than zero.");
            }

            this.passengers = value;
        }
    }

    protected override decimal Calculate()
    {
        double fillPercentage = (double)this.passengers / this.capacity;

        decimal calculatedToll;

        if (fillPercentage < 0.50)
        {
            calculatedToll = this.BaseToll + 2.00m;
        }
        else if (fillPercentage > 0.90)
        {
            calculatedToll = this.BaseToll - 1.00m;
        }
        else
        {
            calculatedToll = this.BaseToll;
        }

        return calculatedToll < 0m ? 0m : calculatedToll;
    }
}
