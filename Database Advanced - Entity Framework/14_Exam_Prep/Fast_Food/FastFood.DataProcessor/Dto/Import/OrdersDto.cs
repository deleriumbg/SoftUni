using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Order")]
    public class OrdersDto
    {
        [Required]
        public string Customer { get; set; }

        public string Employee { get; set; }

        [Required]
        public string DateTime { get; set; }

        public string Type { get; set; }

        [XmlArray("Items")]
        public OrderItemsDto[] OrderItemsDto { get; set; }
    }
}
