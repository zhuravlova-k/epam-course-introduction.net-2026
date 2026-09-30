using System;

namespace InheritanceVehicle;

public class Car : Vehicle
{
    public Car(string name, int maxSpeed)
        : base(name, maxSpeed)
    {
    }

    public void ChangeName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("Name cannot be empty or whitespace.", nameof(newName));
        }

        this.Name = newName;
    }

#pragma warning disable CA1721
    public string GetName()
#pragma warning restore CA1721
    {
        return this.Name;
    }
}
