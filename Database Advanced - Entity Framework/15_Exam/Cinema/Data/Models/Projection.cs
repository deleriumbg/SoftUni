using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Data.Models
{
    //•	Id – integer, Primary Key
    //•	MovieId – integer, foreign key (required)
    //•	Movie – the projection’s movie
    //•	HallId – integer, foreign key (required)
    //•	Hall – the projection’s hall 
    //•	DateTime - DateTime (required)
    //•	Tickets - collection of type Ticket

    public class Projection
    {
        public Projection()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
