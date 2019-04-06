using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    //•	Id – integer, Primary Key
    //•	FullName – text with min length 3 and max length 20 (required)
    //•	Nickname – text starting with "The " and a single word only of letters with an uppercase letter for beginning(example: The Prisoner) (required)
    //•	Age – integer in the range [18, 65] (required)
    //•	IncarcerationDate ¬– Date (required)
    //•	ReleaseDate– Date
    //•	Bail– decimal (non-negative, minimum value: 0)
    //•	CellId - integer, foreign key
    //•	Cell – the prisoner's cell
    //•	Mails - collection of type Mail
    //•	PrisonerOfficers - collection of type OfficerPrisoner

    public class Prisoner
    {
        public Prisoner()
        {
            this.Mails = new HashSet<Mail>();
            this.PrisonerOfficers = new HashSet<OfficerPrisoner>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression("^The [A-Z][a-z]+$")]
        public string Nickname { get; set; }

        [Required]
        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public DateTime IncarcerationDate { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }
        public Cell Cell { get; set; }

        public ICollection<Mail> Mails { get; set; }

        public ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
    }
}