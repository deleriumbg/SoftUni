using System.IO;
using System.Linq;
using P02_DatabaseFirst.Data;

namespace Employee_147
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var e = context.Employees
                    .Where(x => x.EmployeeId == 147)
                    .Select(x => new
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        JobTitle = x.JobTitle,
                        Projects = x.EmployeesProjects.Select(p => p.Project.Name).OrderBy(p => p)
                    })
                    .FirstOrDefault();

                using (StreamWriter sw = new StreamWriter("../../../Employee.txt"))
                {
                    sw.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                    foreach (var p in e.Projects)
                    {
                        sw.WriteLine(p);
                    }
                }
            }
        }
    }
}
