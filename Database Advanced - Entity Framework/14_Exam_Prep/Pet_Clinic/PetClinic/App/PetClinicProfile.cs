using PetClinic.DataProcessor.DTO.Import;
using PetClinic.Models;

namespace PetClinic.App
{
    using AutoMapper;

    public class PetClinicProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public PetClinicProfile()
        {
            CreateMap<AnimalsDto, Animal>();
            CreateMap<PassportDto, Passport>();
        }
    }
}
