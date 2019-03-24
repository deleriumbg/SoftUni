using MyApp.Core.Commands.Contracts;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Core.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        private readonly EmployeesMappingContext context;

        public AddEmployeeCommand(EmployeesMappingContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);

            this.context.Employees.Add(new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            });

            this.context.SaveChanges();

            return $"Successfully added {firstName} {lastName}";
        }
    }
}
