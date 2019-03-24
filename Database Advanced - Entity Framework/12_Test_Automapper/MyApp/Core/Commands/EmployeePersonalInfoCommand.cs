using System;
using System.Linq;
using System.Text;
using MyApp.Core.Commands.Contracts;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly EmployeesMappingContext context;

        public EmployeePersonalInfoCommand(EmployeesMappingContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            StringBuilder output = new StringBuilder();

            var employee = this.context.Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                throw new ArgumentException("Invalid employee id!");
            }

            output.AppendLine($"ID:{employee.Id} - {employee.FirstName} {employee.LastName} - ${employee.Salary:F2}");
            output.AppendLine($"Birthday: {employee.Birthday:dd-MM-yyyy}");
            output.AppendLine($"Address: {employee.Address}");

            return output.ToString().TrimEnd();
        }
    }
}
