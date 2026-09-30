using System;
using System.Collections.Generic;

namespace WorkforceStructure;

public class Company
{
    private readonly IList<Employee> employees;

    public Company(IList<Employee> employees)
    {
        if (employees is not null)
        {
            this.employees = employees;
        }
        else
        {
            throw new ArgumentNullException(nameof(employees));
        }
    }

    public void DistributeBonuses(decimal companyBonus)
    {
        if (companyBonus < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(companyBonus), "Bonus cannot be less than zero.");
        }

        foreach (Employee employee in this.employees)
        {
            employee.AssignBonus(companyBonus);
        }
    }

    public decimal CalculateTotalPayroll()
    {
        decimal totalPayroll = 0m;

        foreach (Employee employee in this.employees)
        {
            totalPayroll += employee.CalculateTotalPay();
        }

        return totalPayroll;
    }

    public string GetHighestPaidEmployeeName()
    {
        if (this.employees.Count == 0)
        {
            throw new InvalidOperationException("There are no employees in the company.");
        }

        Employee highestPaid = this.employees[0];

        for (int i = 1; i < this.employees.Count; i++)
        {
            if (this.employees[i].Salary > highestPaid.Salary)
            {
                highestPaid = this.employees[i];
            }
        }

        return highestPaid.Name;
    }
}
