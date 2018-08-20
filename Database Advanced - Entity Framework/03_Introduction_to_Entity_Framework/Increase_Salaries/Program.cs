using System.IO;
using System.Linq;
using P02_DatabaseFirst.Data;

namespace Increase_Salaries
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                string[] departments = {"Engineering", "Tool Design", "Marketing", "Information Services"};

                var employees = context.Employees
                    .Where(x => departments.Contains(x.Department.Name))
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName);
                    
                using (StreamWriter sw = new StreamWriter("../../../Employees.txt"))
                {
                    foreach (var e in employees)
                    {
                        e.Salary *= 1.12m;
                        sw.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
