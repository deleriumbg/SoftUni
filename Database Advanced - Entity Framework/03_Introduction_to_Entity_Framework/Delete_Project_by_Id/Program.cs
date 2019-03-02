using System.IO;
using System.Linq;
using SoftUni.Data;

namespace Delete_Project_by_Id
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var projectsToDelete = context.EmployeesProjects.Where(x => x.ProjectId == 2);
                context.EmployeesProjects.RemoveRange(projectsToDelete);

                var project = context.Projects.Find(2);
                context.Projects.Remove(project);
                context.SaveChanges();

                var projectsToPrint = context.Projects.Take(10);

                using (StreamWriter sw = new StreamWriter("../../../Projects.txt"))
                {
                    foreach (var p in projectsToPrint)
                    {
                        sw.WriteLine(p.Name);
                    }
                }
            }
        }
    }
}
