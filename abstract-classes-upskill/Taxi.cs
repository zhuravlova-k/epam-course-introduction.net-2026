using System;

namespace TollCalculator;

public class Taxi : Vehicle
{
    private int passengers;

    public Taxi(decimal baseToll, int passengers)
        : base(baseToll)
    {
        if (passengers < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(passengers), "Passengers count cannot be less than zero.");
        }

        this.passengers = passengers;
    }

    public int Passengers
    {
        get => this.passengers;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Passengers count cannot be less than zero.");
            }

            this.passengers = value;
        }
    }

    protected override decimal Calculate()
    {
        decimal calculatedToll = this.passengers switch
        {
            0 => this.BaseToll + 0.50m,
            1 => this.BaseToll,
            2 => this.BaseToll - 0.50m,
            _ => this.BaseToll - 1.00m,
        };

        return calculatedToll < 0m ? 0m : calculatedToll;
    }
}
