using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Villain_Names;

namespace Change_Town_Names_Casing
{
    class Program
    {
        static void Main(string[] args)
        {

            string countryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                int countryId = GetCountryId(countryName, connection);

                if (countryId == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    int affectedRows = UpdateNames(countryId, connection);
                    List<string> names = GetNames(countryId, connection);

                    Console.WriteLine($"{affectedRows} town names were affected. ");
                    Console.WriteLine($"[{string.Join(", ", names)}]");
                }

                connection.Close();
            }
        }

        private static List<string> GetNames(int countryId, SqlConnection connection)
        {
            List<string> names = new List<string>();

            string nameSql = "SELECT Name FROM Towns WHERE CountryCode = @CountryId";

            using (SqlCommand command = new SqlCommand(nameSql, connection))
            {
                command.Parameters.AddWithValue("@CountryId", countryId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add((string)reader[0]);
                    }
                }
            }
            return names;
        }

        private static int UpdateNames(int countryId, SqlConnection connection)
        {
            string updateStatement = @"UPDATE Towns SET [Name] = UPPER([Name]) WHERE CountryCode = @CountryId";

            using (SqlCommand command = new SqlCommand(updateStatement, connection))
            {
                command.Parameters.AddWithValue("@CountryId", countryId);

                return (int)command.ExecuteNonQuery();
            }
        }

        private static int GetCountryId(string countryName, SqlConnection connection)
        {
            string countryInfo = @"SELECT TOP(1) c.Id FROM Towns AS t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.[Name] = @name";
            using (SqlCommand command = new SqlCommand(countryInfo, connection))
            {
                command.Parameters.AddWithValue("@name", countryName);
                if (command.ExecuteScalar() == null)
                {
                    return 0;
                }

                return (int)command.ExecuteScalar();
            }
        }
    }
}
