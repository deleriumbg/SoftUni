using P03_FootballBetting.Data;

namespace P03_FootballBetting 
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (FootballBettingContext context = new FootballBettingContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
