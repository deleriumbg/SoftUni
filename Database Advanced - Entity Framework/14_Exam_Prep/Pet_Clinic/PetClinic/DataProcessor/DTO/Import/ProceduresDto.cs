using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.DTO.Import
{
    //<Procedure>
        //<Vet>Niels Bohr</Vet>
        //<Animal>acattee321</Animal>
        //<DateTime>14-01-2016</DateTime>
        //<AnimalAids>
            //<AnimalAid>
                //<Name>Nasal Bordetella</Name>
            //</AnimalAid>
        //</AnimalAids>
    //</Procedure>

    [XmlType("Procedure")]
    public class ProceduresDto
    {
        [Required]
        public string Vet { get; set; }

        [Required]
        public string Animal { get; set; }

        [Required]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public ProcedureAnimalAidDto[] AnimalAids { get; set; }
    }

    [XmlType("AnimalAid")]
    public class ProcedureAnimalAidDto
    {
        public string Name { get; set; }
    }
}
