using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace Find_Employees_by_First_Name_Starting_With_Sa
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var employees = context.Employees
                    //.Where(x => x.FirstName.StartsWith("Sa"))
                    .Where(x => EF.Functions.Like(x.FirstName, "Sa%"))
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .Select(x => new Employee()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        JobTitle = x.JobTitle,
                        Salary = x.Salary
                    });

                using (StreamWriter sw = new StreamWriter("../../../Employees.txt"))
                {
                    foreach (var e in employees)
                    {
                        sw.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
                    }
                }
            }
        }
    }
}
