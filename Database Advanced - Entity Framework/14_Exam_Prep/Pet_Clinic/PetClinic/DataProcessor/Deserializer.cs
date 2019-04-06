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

                //var animal = Mapper.Map<Animal>(animalDto);
                var animal = new Animal
                {
                    Name = animalDto.Name,
                    Type = animalDto.Type,
                    Age = animalDto.Age,
                    Passport = new Passport
                    {
                        SerialNumber = animalDto.Passport.SerialNumber,
                        OwnerName = animalDto.Passport.OwnerName,
                        OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
                        RegistrationDate = DateTime.ParseExact(animalDto.Passport.RegistrationDate, "dd-MM-yyyy",
                            CultureInfo.InvariantCulture)
                    }
                };

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
            var serializer = new XmlSerializer(typeof(ProceduresDto[]), new XmlRootAttribute("Procedures"));
            var deserializedXml = (ProceduresDto[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
            var procedures = new List<Procedure>();

            foreach (var procedureDto in deserializedXml)
            {
                var vetObj = context.Vets.SingleOrDefault(x => x.Name == procedureDto.Vet);
                var animalObj = context.Animals.SingleOrDefault(a => a.PassportSerialNumber == procedureDto.Animal);

                var validProcedureAnimalAids = new List<ProcedureAnimalAid>();

                var allAidsExists = true;

                foreach (var procedureDtoAnimalAid in procedureDto.AnimalAids)
                {
                    var animalAid = context.AnimalAids
                        .SingleOrDefault(ai => ai.Name == procedureDtoAnimalAid.Name);
                    if (animalAid == null || validProcedureAnimalAids.Any(p => p.AnimalAid.Name == procedureDtoAnimalAid.Name))
                    {
                        allAidsExists = false;
                        break;
                    }

                    var animalAidProcedure = new ProcedureAnimalAid()
                    {
                        AnimalAid = animalAid
                    };

                    validProcedureAnimalAids.Add(animalAidProcedure);
                }

                if (!IsValid(procedureDto) || !procedureDto.AnimalAids.All(IsValid)
                    || vetObj == null || animalObj == null || !allAidsExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var procedure = new Procedure
                {
                    Animal = animalObj,
                    Vet = vetObj,
                    DateTime = DateTime.ParseExact(procedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ProcedureAnimalAids = validProcedureAnimalAids
                };
                procedures.Add(procedure);
                sb.AppendLine("Record successfully imported.");
            }
            context.Procedures.AddRange(procedures);
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
