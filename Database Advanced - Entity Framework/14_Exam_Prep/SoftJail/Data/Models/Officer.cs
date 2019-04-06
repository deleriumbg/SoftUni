using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SoftJail.Data.Models.Enums;

namespace SoftJail.Data.Models
{
    //•	Id – integer, Primary Key
    //•	FullName – text with min length 3 and max length 30 (required)
    //•	Salary – decimal (non-negative, minimum value: 0) (required)
    //•	Position - Position enumeration with possible values: “Overseer, Guard, Watcher, Labour” (required)
    //•	Weapon - Weapon enumeration with possible values: “Knife, FlashPulse, ChainRifle, Pistol, Sniper” (required)
    //•	DepartmentId - integer, foreign key
    //•	Department – the officer's department (required)
    //•	OfficerPrisoners - collection of type OfficerPrisoner

    public class Officer
    {
        public Officer()
        {
            this.OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Salary { get; set; }

        [Required]
        public Position Position{ get; set; }

        [Required]
        public Weapon Weapon { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
    }
}
