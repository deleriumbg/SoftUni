using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using PetClinic.DataProcessor.DTO.Export;
using Formatting = Newtonsoft.Json.Formatting;

namespace PetClinic.DataProcessor
{
    using Data;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals
                .Where(x => x.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(x => new
                {
                    OwnerName = x.Passport.OwnerName,
                    AnimalName = x.Name,
                    Age = x.Age,
                    SerialNumber = x.Passport.SerialNumber,
                    RegisteredOn = x.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                })
                .OrderBy(x => x.Age)
                .ThenBy(x => x.SerialNumber)
                .ToArray();

            string serializedAnimals = JsonConvert.SerializeObject(animals, Formatting.Indented);
            return serializedAnimals;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                .OrderBy(x => x.DateTime)
                .Select(x => new ExportProceduresDto
                {
                    Passport = x.Animal.PassportSerialNumber,
                    OwnerNumber = x.Animal.Passport.OwnerPhoneNumber,
                    DateTime = x.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    AnimalAids = x.ProcedureAnimalAids.Select(a => new ExportAnimalAidsDto
                    {
                        Name = a.AnimalAid.Name,
                        Price = a.AnimalAid.Price
                    })
                    .ToArray(),
                    TotalPrice = x.ProcedureAnimalAids.Sum(ai => ai.AnimalAid.Price)
                })
                .OrderBy(x => x.Passport)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(ExportProceduresDto[]), new XmlRootAttribute("Procedures"));
            serializer.Serialize(new StringWriter(sb), procedures, namespaces);

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
