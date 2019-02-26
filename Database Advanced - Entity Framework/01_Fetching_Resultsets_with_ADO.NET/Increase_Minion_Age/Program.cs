using System;
using System.Data.SqlClient;
using System.Linq;
using Villain_Names;

namespace Increase_Minion_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] minionsId = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                for (int i = 1; i <= 5; i++)
                {
                    if (minionsId.Contains(i))
                    {
                        IncreaseAgeAndCapitalize(i, connection);
                    }
                }

                PrintNameAndAge(connection);

                connection.Close();

            }
        }

        private static void PrintNameAndAge(SqlConnection connection)
        {
            string commandSQL = @"SELECT TOP(5) [Name], Age FROM Minions";

            using (SqlCommand command = new SqlCommand(commandSQL, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]}");
                    }
                }

            }
        }

        private static void IncreaseAgeAndCapitalize(int i, SqlConnection connection)
        {
            string minionSQL = @"UPDATE Minions SET [Name] = UPPER(LEFT([Name],1))+LOWER(SUBSTRING([Name],2,LEN([Name]))), Age = Age + 1 WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(minionSQL, connection))
            {
                command.Parameters.AddWithValue("@Id", i);
                command.ExecuteNonQuery();
            }
        }
    }
}
