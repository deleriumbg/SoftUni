using System;
using System.Linq;
using System.Text;
using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Core.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        private readonly EmployeesMappingContext context;

        public ManagerInfoCommand(EmployeesMappingContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int employeeId = int.Parse(args[0]);

            Employee employee = this.context.Employees.FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid employee id!");
            }

            sb.AppendLine($"{employee.FirstName} {employee.LastName} | Employees: {employee.ManagedEmployees.Count}");

            foreach (var emp in employee.ManagedEmployees)
            {
                sb.AppendLine($"    - {emp.FirstName} {emp.LastName} - ${emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
