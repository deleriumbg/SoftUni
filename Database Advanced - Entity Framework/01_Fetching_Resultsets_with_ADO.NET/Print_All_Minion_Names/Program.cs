using System;
using System.Data.SqlClient;
using Villain_Names;

namespace Print_All_Minion_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstId = 1;
            int lastId = 10;


            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                for (int i = 0; i < lastId / 2; i++)
                {
                    string getFirstName = GetFirstName(firstId + i, connection);
                    string getLastName = GetLastName(lastId - i, connection);

                    Console.WriteLine(getFirstName);
                    Console.WriteLine(getLastName);
                }

                connection.Close();
            }
        }

        private static string GetLastName(int lastId, SqlConnection connection)
        {
            string nameSQL = "SELECT [Name] FROM Minions WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(nameSQL, connection))
            {
                command.Parameters.AddWithValue("@Id", lastId);
                return (string)command.ExecuteScalar();
            }
        }

        private static string GetFirstName(int firstId, SqlConnection connection)
        {
            string nameSQL = "SELECT [Name] FROM Minions WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(nameSQL, connection))
            {
                command.Parameters.AddWithValue("@Id", firstId);
                return (string)command.ExecuteScalar();
            }
        }
    }
}
