using System.IO;
using System.Linq;
using SoftUni.Data;

namespace Addresses_by_Town
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var addresses = context.Addresses
                    .OrderByDescending(x => x.Employees.Count)
                    .ThenBy(x => x.Town.Name)
                    .ThenBy(x => x.AddressText)
                    .Select(x => new
                    {
                        AddressText = x.AddressText,
                        TownName = x.Town.Name,
                        EmployeeCount = x.Employees.Count,
                    }).Take(10);

                using (StreamWriter sw = new StreamWriter("../../../Addresses.txt"))
                {
                    foreach (var a in addresses)
                    {
                        sw.WriteLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
                    }
                }
            }
        }
    }
}
