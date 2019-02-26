using System;
using System.Data.SqlClient;
using Villain_Names;


namespace Add_Minion
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] minionsInfo = Console.ReadLine().Split();
            string[] vilianInfo = Console.ReadLine().Split();

            string minionsName = minionsInfo[1];
            int age = int.Parse(minionsInfo[2]);
            string townName = minionsInfo[3];

            string vilianName = vilianInfo[1];

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                int townId = GetTownId(townName, connection);
                int vilianId = GetVilianId(vilianName, connection);
                int minionId = InsertMinionsAndGetId(minionsName, age, townId, connection);
                AssignMinionToVilian(vilianId, minionId, connection);
                Console.WriteLine($"Successfully added {minionsName} to be minion of {vilianName}.");
                connection.Close();
            }
        }

        private static void AssignMinionToVilian(int vilianId, int minionId, SqlConnection connection)
        {
            string insertIntoMinionsVilian = @"INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(@minionId, @vilianId)";

            using (SqlCommand command = new SqlCommand(insertIntoMinionsVilian, connection))
            {
                command.Parameters.AddWithValue("@minionId", minionId);
                command.Parameters.AddWithValue("@vilianId", vilianId);
                command.ExecuteNonQuery();
            }
        }

        private static int InsertMinionsAndGetId(string minionsName, int age, int townId, SqlConnection connection)
        {
            string insertMinion = @"INSERT INTO Minions(Name, Age, TownId) VALUES(@name, @age, @townId)";

            using (SqlCommand command = new SqlCommand(insertMinion, connection))
            {
                command.Parameters.AddWithValue("@name", minionsName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@townId", townId);
                command.ExecuteNonQuery();
            }

            string minionsSQL = @"SELECT Id FROM Minions WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(minionsSQL, connection))
            {
                command.Parameters.AddWithValue("@Name", minionsName);
                return (int)command.ExecuteScalar();
            }
        }

        private static int GetVilianId(string vilianName, SqlConnection connection)
        {
            string vilianId = @"SELECT Id FROM Villains WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(vilianId, connection))
            {
                command.Parameters.AddWithValue("@Name", vilianName);

                if (command.ExecuteScalar() == null)
                {
                    InsertIntoVilians(vilianName, connection);
                    Console.WriteLine($"Villain {vilianName} was added to the database.");
                }

                return (int)command.ExecuteScalar();
            }
        }

        private static void InsertIntoVilians(string vilianName, SqlConnection connection)
        {
            string insertVilian = "INSERT INTO Villains (Name) Values (@vilianName)";

            using (SqlCommand command = new SqlCommand(insertVilian, connection))
            {
                command.Parameters.AddWithValue("@vilianName", vilianName);
                command.ExecuteNonQuery();
            }
        }

        private static int GetTownId(string townName, SqlConnection connection)
        {
            string townId = @"SELECT Id FROM Towns WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(townId, connection))
            {
                command.Parameters.AddWithValue("@Name", townName);

                if (command.ExecuteScalar() == null)
                {
                    InsertIntoTowns(townName, connection);
                    Console.WriteLine($"Town {townName} was added to the database.");
                }

                return (int)command.ExecuteScalar();
            }
        }

        private static void InsertIntoTowns(string townName, SqlConnection connection)
        {
            string insertTown = "INSERT INTO Towns (Name) Values (@townName)";

            using (SqlCommand command = new SqlCommand(insertTown, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);
                command.ExecuteNonQuery();
            }
        }
    }
}

