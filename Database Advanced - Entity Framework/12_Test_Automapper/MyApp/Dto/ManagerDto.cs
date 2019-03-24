using System.Collections.Generic;

namespace MyApp.Dto
{
    public class ManagerDto
    {

        public ManagerDto()
        {
            this.ManagedEmployees = new HashSet<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> ManagedEmployees { get; set; }
    }
}
