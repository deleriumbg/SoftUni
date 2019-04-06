using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    //•	PrisonerId – integer, Primary Key
    //•	Prisoner – the officer’s prisoner (required)
    //•	OfficerId – integer, Primary Key
    //•	Officer – the prisoner’s officer (required)

    public class OfficerPrisoner
    {
        public int PrisonerId { get; set; }
        public Prisoner Prisoner { get; set; }

        public int OfficerId { get; set; }
        public Officer Officer { get; set; }
    }
}
