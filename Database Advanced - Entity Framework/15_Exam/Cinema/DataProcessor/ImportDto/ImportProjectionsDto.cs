using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    //<Projection>
        //<MovieId>38</MovieId>
        //<HallId>4</HallId>
        //<DateTime>2019-04-27 13:33:20</DateTime>
    //</Projection>

    [XmlType("Projection")]
    public class ImportProjectionsDto
    {
        public int MovieId { get; set; }

        public int HallId { get; set; }

        [Required]
        public string DateTime { get; set; }
    }
}
