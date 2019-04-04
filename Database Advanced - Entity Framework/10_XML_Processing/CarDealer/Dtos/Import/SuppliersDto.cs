using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    //<Supplier>
        //<name>3M Company</name>
        //<isImporter>true</isImporter>
    //</Supplier>

    [XmlType("Supplier")]
    public class SuppliersDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
