using System;

namespace WorkforceStructure;

public class SalesPerson : Employee
{
    private readonly int salesPercentage;

    public SalesPerson(string name, decimal salary, int salesPercentage)
        : base(name, salary)
    {
        if (salesPercentage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(salesPercentage), "Sales percentage cannot be less than zero.");
        }

        this.salesPercentage = salesPercentage;
    }

    public override void AssignBonus(decimal bonus)
    {
        if (bonus < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bonus), "Bonus cannot be less than zero.");
        }

        decimal finalBonus = bonus;

        if (this.salesPercentage > 200)
        {
            finalBonus *= 3;
        }
        else if (this.salesPercentage > 100)
        {
            finalBonus *= 2;
        }

        base.AssignBonus(finalBonus);
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Sales Percentage: {this.salesPercentage}%";
    }
}
