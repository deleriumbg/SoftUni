using System.IO;
using System.Linq;
using SoftUni.Data;
using SoftUni.Models;

namespace Find_Latest_10_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var projects = context.Projects
                    .OrderByDescending(x => x.StartDate)
                    .Take(10)
                    .OrderBy(x => x.Name)
                    .Select(x => new Project
                    {
                        Name = x.Name,
                        Description = x.Description,
                        StartDate = x.StartDate
                    });

                using (StreamWriter sw = new StreamWriter("../../../Projects.txt"))
                {
                    foreach (var p in projects)
                    {
                        sw.WriteLine($"{p.Name}\r\n{p.Description}\r\n{p.StartDate:M/d/yyyy h:mm:ss tt}");
                    }
                }
            }
        }
    }
}
