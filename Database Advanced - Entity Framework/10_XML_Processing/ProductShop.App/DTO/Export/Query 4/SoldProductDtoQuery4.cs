using System.Xml.Serialization;

namespace ProductShop.App.DTO.Export
{
    [XmlType("sold-products")]
    public class SoldProductDtoQuery4
    {
        [XmlAttribute("count")] 
        public int Count { get; set; }

        [XmlElement("product")] 
        public ProductDtoQuery4[] ProductDto { get; set; }
    }
}
