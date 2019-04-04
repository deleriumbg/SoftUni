using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    //<Category>
        //<name>Drugs</name>
    //</Category>

    [XmlType("Category")]
    public class CategoryDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
