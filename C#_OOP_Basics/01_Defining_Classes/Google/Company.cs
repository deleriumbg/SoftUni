public class Company
{
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public Company(string name, string department, double salary)
    {
        Name = name;
        Department = department;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Department} {this.Salary:f2}";
    }
}
