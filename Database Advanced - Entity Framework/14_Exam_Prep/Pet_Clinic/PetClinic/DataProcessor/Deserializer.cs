using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using Newtonsoft.Json;
using PetClinic.DataProcessor.DTO.Import;
using PetClinic.Models;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace PetClinic.DataProcessor
{
    using System;
    using Data;

    public class Deserializer
    {
        private const string FailureMessage = "Error: Invalid data.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var deserializedAnimalAids = JsonConvert.DeserializeObject<AnimalAidsDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            var animalAids = new List<AnimalAid>();

            foreach (var animalAidsDto in deserializedAnimalAids)
            {
                bool animalAidExists = animalAids.Any(x => x.Name == animalAidsDto.Name);

                if (!IsValid(animalAidsDto) || animalAidExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var animalAid = new AnimalAid
                {
                    Name = animalAidsDto.Name,
                    Price = animalAidsDto.Price
                };

                animalAids.Add(animalAid);
                sb.AppendLine($"Record {animalAid.Name} successfully imported.");
            }

            context.AnimalAids.AddRange(animalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var deserializedAnimals = JsonConvert.DeserializeObject<AnimalsDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            var animals = new List<Animal>();

            foreach (var animalDto in deserializedAnimals)
            {
                bool passportSerialNumberExists =
                    animals.Any(x => x.Passport.SerialNumber == animalDto.Passport.SerialNumber);

                if (!IsValid(animalDto) || !IsValid(animalDto.Passport) || passportSerialNumberExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var animal = Mapper.Map<Animal>(animalDto);

                animals.Add(animal);
                sb.AppendLine($"Record {animalDto.Name} Passport №: {animalDto.Passport.SerialNumber} successfully imported.");
            }

            context.Animals.AddRange(animals);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(VetsDto[]), new XmlRootAttribute("Vets"));
            var deserizlizedVets = (VetsDto[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
            var vets = new List<Vet>();

            foreach (var vetDto in deserizlizedVets)
            {
                var vetExists = vets.Any(x => x.PhoneNumber == vetDto.PhoneNumber);

                if (!IsValid(vetDto) || vetExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var vet = new Vet
                {
                    Name = vetDto.Name,
                    Profession = vetDto.Profession,
                    Age = vetDto.Age,
                    PhoneNumber = vetDto.PhoneNumber
                };

                vets.Add(vet);
                sb.AppendLine($"Record {vet.Name} successfully imported.");
            }

            context.Vets.AddRange(vets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var procedures = new List<Procedure>();
            var procedureAnimalAids = new List<ProcedureAnimalAid>();
            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(ProceduresDto[]), new XmlRootAttribute("Procedures"));
            ProceduresDto[] procedureDtos = (ProceduresDto[])serializer.Deserialize(new StringReader(xmlString));

            foreach (var procDto in procedureDtos)
            {
                bool areValidAnimalAids = true;

                if (!IsValid(procDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                foreach (var animalAidDto in procDto.AnimalAids)
                {
                    if (!IsValid(animalAidDto))
                    {
                        areValidAnimalAids = false;
                        break;
                    }
                }

                if (!areValidAnimalAids)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Vet vet = context.Vets.FirstOrDefault(v => v.Name == procDto.Vet);
                Animal animal = context.Animals.FirstOrDefault(a => a.PassportSerialNumber == procDto.Animal);
                if (vet == null || animal == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                IEnumerable<string> animalAidNames = procDto.AnimalAids.Select(aa => aa.Name);
                var animalAids = new List<AnimalAid>();

                bool allAidsExist = true;
                foreach (string name in animalAidNames)
                {
                    AnimalAid animalAid = context.AnimalAids.FirstOrDefault(aa => aa.Name == name);

                    if (animalAid == null)
                    {
                        allAidsExist = false;
                        break;
                    }

                    animalAids.Add(animalAid);
                }

                bool haveDuplicateNames = animalAidNames.GroupBy(n => n).Any(g => g.Count() > 1);
                if (!allAidsExist || haveDuplicateNames)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                
                DateTime dateTime = DateTime.Parse(procDto.DateTime);
                var procedure = new Procedure
                {
                    Animal = animal,
                    Vet = vet,
                    DateTime = dateTime,
                };
                procedures.Add(procedure);

                foreach (AnimalAid animalAid in animalAids)
                {
                    var procAnimalAid = new ProcedureAnimalAid
                    {
                        Procedure = procedure,
                        AnimalAid = animalAid
                    };
                    procedureAnimalAids.Add(procAnimalAid);
                }

                sb.AppendLine("Record successfully imported.");
            }

            context.ProceduresAnimalAids.AddRange(procedureAnimalAids);
            context.Procedures.AddRange(procedures);
            context.SaveChanges();

            return sb.ToString();
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
