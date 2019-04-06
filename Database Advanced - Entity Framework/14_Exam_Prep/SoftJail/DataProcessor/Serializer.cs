using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.DataProcessor.ExportDto;
using SoftJail.DataProcessor.ImportDto;
using Formatting = Newtonsoft.Json.Formatting;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(p => new
                    {
                        OfficerName = p.Officer.FullName,
                        Department = p.Officer.Department.Name
                    })
                    .OrderBy(p => p.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = x.PrisonerOfficers.Select(o => o.Officer.Salary).Sum()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            string serializedPrisoners = JsonConvert.SerializeObject(prisoners, Formatting.Indented);
            return serializedPrisoners;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var selectedPrisoners = prisonersNames.Split(',');

            var prisoners = context.Prisoners
                .Where(x => selectedPrisoners.Contains(x.FullName))
                .Select(x => new InboxForPrisonerDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails.Select(m => new MessagesDto
                    {
                        Description = ReverseString(m.Description)
                    })
                    .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(InboxForPrisonerDto[]), new XmlRootAttribute("Prisoners"));
            serializer.Serialize(new StringWriter(sb), prisoners, namespaces);

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ReverseString(string text)
        {
            return new string(text.Reverse().ToArray());
        }
    }
}