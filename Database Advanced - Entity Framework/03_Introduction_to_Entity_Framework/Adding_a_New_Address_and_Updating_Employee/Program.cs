using System.IO;
using System.Linq;
using SoftUni.Data;
using SoftUni.Models;

namespace Adding_a_New_Address_and_Updating_Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var address = new Address()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                Employee employee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
                employee.Address = address;
                context.SaveChanges();

                var addresses = context.Employees
                    .OrderByDescending(x => x.AddressId)
                    .Select(x => x.Address.AddressText)
                    .Take(10);

                using (StreamWriter sw = new StreamWriter("../../../Addresses.txt"))
                {
                    foreach (var addressText in addresses)
                    {
                        sw.WriteLine(addressText);
                    }
                }
            }
        }
    }
}
