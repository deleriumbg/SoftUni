using System;
using System.Data.SqlClient;
using Villain_Names;

namespace Increase_Age_Stored_Procedure
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("usp_GetOlder", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure


                })
                {
                    command.Parameters.AddWithValue("@Id", id);
                    string result = (string)command.ExecuteScalar();
                    Console.WriteLine(result);
               
                }
                connection.Close();
            }
        }
    }
}
