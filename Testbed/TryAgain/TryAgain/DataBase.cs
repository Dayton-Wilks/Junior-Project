using System;
using System.Data.SqlClient;
namespace TryAgain
{
    public static class DataBase
    {
        // User connection details.
        static string DB_NAME = "certitracker";
        static string DB_USER_NAME;
        static string DB_USER_PWD;

        private static void GetPassword()
        {
            Console.Write("Username: ");
            DB_USER_NAME = Console.ReadLine();
            Console.Write("Password: ");
            DB_USER_PWD = Console.ReadLine();
        }

        public static SqlConnection GetConnection()
        {
            GetPassword();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =

                // This is where the database can be found.
                "Data Source=satou.cset.oit.edu" +
                ";Initial Catalog=" + DB_NAME +
                ";Integrated Security=False" +
                ";User ID=" + DB_USER_NAME + ";Password=" + DB_USER_PWD
                ;
            return connection;
        }
    }
}
