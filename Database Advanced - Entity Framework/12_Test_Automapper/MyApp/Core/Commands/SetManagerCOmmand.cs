using System;
using System.Linq;
using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly EmployeesMappingContext context;

        public SetManagerCommand(EmployeesMappingContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            Employee employee = this.context.Employees.FirstOrDefault(e => e.Id == employeeId);
            Employee manager = this.context.Employees.FirstOrDefault(e => e.Id == managerId);

            if (employee == null || manager == null)
            {
                throw new InvalidOperationException();
            }

            manager.ManagedEmployees.Add(employee);
            employee.Manager = manager;
            employee.ManagerId = managerId;
            this.context.SaveChanges();

            return $"Successfully set manager for {employee.FirstName} {employee.LastName} to {manager.FirstName} {manager.LastName}";
        }
    }
}
