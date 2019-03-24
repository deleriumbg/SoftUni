using System;
using System.Linq;
using MyApp.Core.Commands.Contracts;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class SetAddressCommand : ICommand
    {
        private readonly EmployeesMappingContext context;

        public SetAddressCommand(EmployeesMappingContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);
            string address = args[1];

            var employee = this.context.Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                throw new ArgumentException("Invalid employee id!");
            }

            employee.Address = address;

            this.context.SaveChanges();

            return $"Successfully set address for {employee.FirstName} {employee.LastName} to {address}";
        }
    }
}
