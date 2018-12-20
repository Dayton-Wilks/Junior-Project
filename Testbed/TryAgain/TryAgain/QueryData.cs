using System;
using System.Data.SqlClient;

namespace TryAgain
{
    public static class QueryData
    {
        public static void SelectAllFromTable(string tableName, string whereClause = null)
        {
            SqlConnection connection = null;

            try
            {
                //Get the connection to the database
                connection = DataBase.GetConnection();

                ////create the SQL Command
                string commandText = "Select * FROM " + tableName;

                if (whereClause != null)
                    commandText += "WHERE " + whereClause;


                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();

                //Start reading from the database
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //Write the column names to the console
                    if (reader.HasRows)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader.GetName(i) + " | ");
                        }
                    }

                    Console.WriteLine();

                    int rowCount = 0;

                    //Write each row to the console
                    while (reader.Read())
                    {
                        rowCount++;

                        int result = reader.GetInt32(0);

                        for (int i = 0; i < reader.FieldCount; i++)
                        {

                            if(reader[i].ToString() != "")
                                Console.Write(Convert.ToString(reader[i]) + " | ");
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine(rowCount.ToString() + " Rows returned.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
