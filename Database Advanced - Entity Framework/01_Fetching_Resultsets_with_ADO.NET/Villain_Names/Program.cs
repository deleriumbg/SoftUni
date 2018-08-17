using System;
using System.Data.SqlClient;

namespace Villain_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                //SELECT v.[Name], COUNT(mv.MinionId) AS MinionsCount FROM Villains AS v
                //JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                //GROUP BY v.[Name]
                //HAVING COUNT(mv.MinionId) >= 3 
                //ORDER BY MinionsCount DESC

                string minionsCountPerVillain = "SELECT v.[Name], COUNT(mv.MinionId) AS MinionsCount FROM Villains AS v JOIN MinionsVillains AS mv ON v.Id = mv.VillainId GROUP BY v.[Name] HAVING COUNT(mv.MinionId) >= 3 ORDER BY MinionsCount DESC";

                using (SqlCommand command = new SqlCommand(minionsCountPerVillain, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} -> {reader[1]}");
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
