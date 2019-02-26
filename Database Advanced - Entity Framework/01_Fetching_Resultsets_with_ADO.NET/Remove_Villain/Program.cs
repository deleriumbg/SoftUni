using System;
using System.Data.SqlClient;
using Villain_Names;

namespace Remove_Villain
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputVillianId = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();


                int villainId = GetVillainId(inputVillianId, connection, transaction);

                if (villainId == 0)
                {
                    Console.WriteLine("No such villain was found.");
                }
                else
                {
                    try
                    {
                        int affectedRows = ReleaseMinions(villainId, connection, transaction);
                        string villainName = GetVillainName(villainId, connection, transaction);
                        DeleteVillain(villainId, connection, transaction);
                        Console.WriteLine($"{villainName} was deleted.");
                        Console.WriteLine($"{affectedRows} minions were released.");
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                }
                connection.Close();
            }
        }

        private static void DeleteVillain(int villainId, SqlConnection connection, SqlTransaction transaction)
        {
            string deleteVillain = "DELETE FROM Villains WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(deleteVillain, connection, transaction))
            {
                command.Parameters.AddWithValue("@Id", villainId);
                command.ExecuteNonQuery();
            }
        }

        private static string GetVillainName(int villainId, SqlConnection connection, SqlTransaction transaction)
        {
            string nameSQL = @"SELECT [Name] FROM Villains WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(nameSQL, connection, transaction))
            {
                command.Parameters.AddWithValue("@Id", villainId);
                return (string)command.ExecuteScalar();
            }
        }

        private static int ReleaseMinions(int villainId, SqlConnection connection, SqlTransaction transaction)
        {
            string releaseMinions = @"DELETE FROM MinionsVillains WHERE  VillainId = @villainId";
            using (SqlCommand command = new SqlCommand(releaseMinions, connection, transaction))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                return command.ExecuteNonQuery();
            }
        }

        private static int GetVillainId(int inputVillianId, SqlConnection connection, SqlTransaction transaction)
        {
            string villainInfo = "SELECT Id FROM Villains WHERE ID = @Id";

            using (SqlCommand command = new SqlCommand(villainInfo, connection, transaction))
            {
                command.Parameters.AddWithValue("@Id", inputVillianId);

                if (command.ExecuteScalar() == null)
                {
                    return 0;
                }

                return (int)command.ExecuteScalar();
            }
        }
    }
}
