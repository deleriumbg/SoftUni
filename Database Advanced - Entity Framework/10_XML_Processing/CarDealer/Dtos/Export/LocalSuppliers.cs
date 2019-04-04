using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    //<suppliers>
        //<suplier id="2" name="VF Corporation" parts-count="3" />
        //<suplier id="5" name="Saks Inc" parts-count="2" />
    //</suppliers>

    [XmlType("suplier")]
    public class LocalSuppliers
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}
