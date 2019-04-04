using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    //<Sale>
        //<carId>105</carId>
        //<customerId>30</customerId>
        //<discount>30</discount>
    //</Sale>

    [XmlType("Sale")]
    public class SalesDto
    {
        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }
    }
}
