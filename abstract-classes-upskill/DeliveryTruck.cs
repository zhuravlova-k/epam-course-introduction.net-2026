using System;

namespace TollCalculator;

public class DeliveryTruck : Vehicle
{
    private readonly int grossWeightClass;

    public DeliveryTruck(decimal baseToll, int grossWeightClass)
        : base(baseToll)
    {
        if (grossWeightClass <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(grossWeightClass), "Gross weight class must be greater than zero.");
        }

        this.grossWeightClass = grossWeightClass;
    }

    public int GrossWeightClass => this.grossWeightClass;

    protected override decimal Calculate()
    {
        if (this.grossWeightClass > 5000)
        {
            return this.BaseToll + 5.00m;
        }
        else if (this.grossWeightClass < 3000)
        {
            decimal finalToll = this.BaseToll - 2.00m;
            return finalToll < 0m ? 0m : finalToll;
        }

        return this.BaseToll;
    }
}
