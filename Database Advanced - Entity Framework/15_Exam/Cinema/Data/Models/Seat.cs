namespace Cinema.Data.Models
{
    //•	Id – integer, Primary Key
    //•	HallId – integer, foreign key (required)
    //•	Hall – the seat’s hall 

    public class Seat
    {
        public int Id { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
