using System;
using System.Linq;
using MyApp.Core.Commands.Contracts;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class SetBirthdayCommand : ICommand
    {
        private readonly EmployeesMappingContext context;

        public SetBirthdayCommand(EmployeesMappingContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);
            DateTime birthday = DateTime.Parse(args[1]);

            var employee = this.context.Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                throw new ArgumentException("Invalid employee id!");
            }

            employee.Birthday = birthday;
            this.context.SaveChanges();

            return $"Successfully set birthday for {employee.FirstName} {employee.LastName} to {birthday}";
        }
    }
}
