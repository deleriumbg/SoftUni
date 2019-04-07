using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    //<Customer>
        //<FirstName>Randi</FirstName>
        //<LastName>Ferraraccio</LastName>
        //<Age>20</Age>
        //<Balance>59.44</Balance>
        //<Tickets>
            //<Ticket>
                //<ProjectionId>1</ProjectionId>
                //<Price>7</Price>
            //</Ticket>
        //</Tickets>
    //</Customer>

    [XmlType("Customer")]
    public class CustomersTicketsDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [Range(12, 110)]
        public int Age { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public TicketsDto[] Tickets { get; set; }
    }

    [XmlType("Ticket")]
    public class TicketsDto
    {
        [Required]
        public int ProjectionId { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
