using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var deserializedDepartments = JsonConvert.DeserializeObject<Department[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            var departments = new List<Department>();

            foreach (var currentDepartment in deserializedDepartments)
            {
                if (!IsValid(currentDepartment) || !currentDepartment.Cells.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var department = new Department
                {
                    Name = currentDepartment.Name,
                };

                foreach (var currentCell in currentDepartment.Cells)
                {
                    department.Cells.Add(new Cell
                    {
                        CellNumber = currentCell.CellNumber,
                        HasWindow = currentCell.HasWindow
                    });
                }

                departments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var deserializedPrisoners = JsonConvert.DeserializeObject<PrisonersDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            var prisoners = new List<Prisoner>();

            foreach (var prisonerDto in deserializedPrisoners)
            {
                if (!IsValid(prisonerDto) || !prisonerDto.Mails.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var releaseDate = prisonerDto.ReleaseDate == null
                    ? (DateTime?)null
                    : DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture),
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    Mails = prisonerDto.Mails.Select(m => new Mail
                    {
                        Description = m.Description,
                        Sender = m.Sender,
                        Address = m.Address
                    }).ToArray()
                };

                //foreach (var mailDto in prisonerDto.Mails)
                //{
                //    prisoner.Mails.Add(new Mail
                //    {
                //        Description = mailDto.Description,
                //        Sender = mailDto.Sender,
                //        Address = mailDto.Address
                //    });
                //}

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OfficersDto[]), new XmlRootAttribute("Officers"));
            var deserizlizedOfficers = (OfficersDto[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
            var officers = new List<Officer>();

            foreach (var officerDto in deserizlizedOfficers)
            {
                var validPosition = Enum.TryParse<Position>(officerDto.Position, out Position position);
                var validWeapon = Enum.TryParse<Weapon>(officerDto.Weapon, out Weapon weapon);

                if (!IsValid(officerDto) || !validPosition || !validWeapon)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerDto.DepartmentId,
                    OfficerPrisoners = officerDto.Prisoners.Select(o => new OfficerPrisoner
                    {
                        PrisonerId = o.Id
                    }).ToArray()
                };

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();
            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}