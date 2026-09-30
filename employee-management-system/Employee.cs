using System;

namespace WorkforceStructure;

public class Employee
{
    private readonly string name;
    private decimal salary;
    private decimal bonus;

    public Employee(string name, decimal salary)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null, empty or whitespace.", nameof(name));
        }

        this.name = name;
        this.Salary = salary;
        this.bonus = 0m;
    }

    public string Name => this.name;

    public decimal Salary
    {
        get => this.salary;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Salary cannot be less than zero.");
            }

            this.salary = value;
        }
    }

    public virtual void AssignBonus(decimal bonus)
    {
        if (bonus < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bonus), "Bonus cannot be less than zero.");
        }

        this.bonus = bonus;
    }

    public decimal CalculateTotalPay()
    {
        return this.salary + this.bonus;
    }

    public override string ToString()
    {
        return $"{this.Name}, Salary: {this.Salary:C}, Bonus: {this.bonus:C}";
    }
}
