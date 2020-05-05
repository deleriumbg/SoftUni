using System.Collections.Generic;

class Department
{
    public string Name { get; set; }
    public List<decimal> Salaries { get; set; }

    public Department(string name, List<decimal> salaries)
    {
        Name = name;
        Salaries = salaries;
    }
}
