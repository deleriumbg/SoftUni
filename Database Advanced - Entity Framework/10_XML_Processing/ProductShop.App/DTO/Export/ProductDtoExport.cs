using System.Xml.Serialization;

namespace ProductShop.App.DTO.Export
{
    [XmlType("product")]
    public class ProductDtoExport
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("buyer")]
        public string Buyer { get; set; }
    }
}
