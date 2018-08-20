using System;
using System.Linq;
using P02_DatabaseFirst.Data;

namespace P02_DatabaseFirst
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var employees = context.Employees.ToArray();

                foreach (var e in employees)
                {
                    Console.WriteLine(e.FirstName);
                }
            }
        }
    }
}
