using System;

namespace WorkforceStructure;

public class Manager : Employee
{
    private readonly int clientCount;

    public Manager(string name, decimal salary, int clientCount)
        : base(name, salary)
    {
        if (clientCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(clientCount), "Client count cannot be less than zero.");
        }

        this.clientCount = clientCount;
    }

    public override void AssignBonus(decimal bonus)
    {
        if (bonus < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bonus), "Bonus cannot be less than zero.");
        }

        decimal finalBonus = bonus;

        if (this.clientCount > 150)
        {
            finalBonus += 1000m;
        }
        else if (this.clientCount > 100)
        {
            finalBonus += 500m;
        }

        base.AssignBonus(finalBonus);
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Clients: {this.clientCount}";
    }
}
