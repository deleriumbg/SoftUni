using System.IO;
using System.Linq;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;

namespace Departments_With_More_Than_5_Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var departments = context.Departments
                    .Where(x => x.Employees.Count > 5)
                    .OrderBy(x => x.Employees.Count)
                    .ThenBy(x => x.Name)
                    .Select(x => new 
                    {
                        DepartmentName = x.Name,
                        ManagerName = $"{x.Manager.FirstName} {x.Manager.LastName}",
                        Employees = x.Employees.Select(e => new Employee()
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            JobTitle = e.JobTitle
                        }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
                    });

                using (StreamWriter sw = new StreamWriter("../../../Departments.txt"))
                {
                    foreach (var d in departments)
                    {
                        sw.WriteLine($"{d.DepartmentName} - {d.ManagerName}");
                        foreach (var e in d.Employees)
                        {
                            sw.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                        }
                        sw.WriteLine("----------");
                    }
                }
            }
        }
    }
}
