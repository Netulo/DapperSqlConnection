using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;

namespace DapperSqlConnection
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            
            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Połączono");
                var result = connection.Query<User>("select * FROM [Dapper].[dbo].[User]");

                foreach (var item in result)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Surname);
                }
            }
        }
    }
}

