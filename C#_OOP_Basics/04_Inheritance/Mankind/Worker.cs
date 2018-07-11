using System;
using System.Text;

public class Worker : Human
{
    private const decimal MIN_WEEKLY_SALARY = 10;
    private const int MIN_HOURS_WORKED = 1;
    private const int MAX_HOURS_WORKED = 12;
    private decimal weekSalary;
    private double workHoursPerDay;

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value < MIN_WEEKLY_SALARY)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(weekSalary)}");
            }
            weekSalary = value;
        }
    }

    public double WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < MIN_HOURS_WORKED || value > MAX_HOURS_WORKED)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(workHoursPerDay)}");
            }
            workHoursPerDay = value;
        }
    }

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay) : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        WorkHoursPerDay = workHoursPerDay;
    }

    public decimal CalculateSalaryPerHour()
    {
        return this.WeekSalary / (decimal)(this.WorkHoursPerDay * 5);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine(base.ToString())
            .AppendLine($"Week Salary: {this.WeekSalary:f2}")
            .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
            .AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");
        return result.ToString().TrimEnd();
    }
}
