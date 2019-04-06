using System.Xml.Serialization;

namespace PetClinic.DataProcessor.DTO.Export
{
    //<Procedure>
        //<Passport>acattee321</Passport>
        //<OwnerNumber>0887446123</OwnerNumber>
        //<DateTime>14-01-2016</DateTime>
        //<AnimalAids>
            //<AnimalAid>
                //<Name>Internal Deworming</Name>
                //<Price>8.00</Price>
            //</AnimalAid>
        //</AnimalAids>
        //<TotalPrice>21.10</TotalPrice>
    //</Procedure>

    [XmlType("Procedure")]
    public class ExportProceduresDto
    {
        public string Passport { get; set; }

        public string OwnerNumber { get; set; }

        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public ExportAnimalAidsDto[] AnimalAids { get; set; }

        public decimal TotalPrice { get; set; }
    }

    [XmlType("AnimalAid")]
    public class ExportAnimalAidsDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
