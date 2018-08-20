using System.IO;
using System.Linq;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;

namespace Employees_Full_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var employees = context.Employees.OrderBy(x => x.EmployeeId).Select(x => new Employee()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    JobTitle = x.JobTitle,
                    Salary = x.Salary
                });

                using (StreamWriter sw = new StreamWriter("../../../Employees.txt"))
                {
                    foreach (var e in employees)
                    {
                        sw.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
                    }
                }
            }
        }
    }
}
