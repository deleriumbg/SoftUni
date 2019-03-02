using System.IO;
using System.Linq;
using SoftUni.Data;

namespace Employees_and_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                    .Select(x => new
                    {
                        EmployeeName = $"{x.FirstName} {x.LastName}",
                        ManagerName = $"{x.Manager.FirstName} {x.Manager.LastName}",
                        Projects = x.EmployeesProjects.Select(p => new
                        {
                            ProjectName = p.Project.Name,
                            StartDate = p.Project.StartDate,
                            EndDate = p.Project.EndDate
                        })
                    }).Take(30);

                using (StreamWriter sw = new StreamWriter("../../../Employees.txt"))
                {
                    foreach (var e in employees)
                    {
                        sw.WriteLine($"{e.EmployeeName} - Manager: {e.ManagerName}");
                        foreach (var p in e.Projects)
                        {
                            sw.WriteLine($"--{p.ProjectName} - {p.StartDate:M/d/yyyy h:mm:ss tt} - {p.EndDate?.ToString("M/d/yyyy h:mm:ss tt") ?? "not finished"}");
                        }
                    }
                }
            }
        }
    }
}
