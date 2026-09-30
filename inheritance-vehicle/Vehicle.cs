using System;

namespace InheritanceVehicle;

public class Vehicle
{
    private readonly int maxSpeed;
    private string name;

    protected Vehicle(string name, int maxSpeed)
    {
        this.name = name;
        this.maxSpeed = maxSpeed;
    }

    public int MaxSpeed => this.maxSpeed;

    protected string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty or whitespace.", nameof(value));
            }

            this.name = value;
        }
    }
}
