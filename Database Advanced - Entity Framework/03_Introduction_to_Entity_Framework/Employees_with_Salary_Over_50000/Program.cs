using System.IO;
using System.Linq;
using P02_DatabaseFirst.Data;

namespace Employees_with_Salary_Over_50000
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var employeeNames = context.Employees.Where(x => x.Salary > 50000).OrderBy(x => x.FirstName).Select(x => x.FirstName);

                using (StreamWriter sw = new StreamWriter("../../../Employees.txt"))
                {
                    foreach (var name in employeeNames)
                    {
                        sw.WriteLine(name);
                    }
                }
            }
        }
    }
}
