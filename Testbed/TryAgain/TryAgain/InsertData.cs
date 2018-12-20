using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TryAgain
{
    public static class InsertData
    {
        public static string Schema;

        public static void WriteUser(string FirstName, string LastName, string Email, string AreaInterest = null, string Background = null, string Location = null)
        {
            SqlConnection connection = null;
            try
            {
                //Write user to database
                connection = DataBase.GetConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText =
                    "INSERT INTO " + Schema + ".Users (FName, LName, Email, AreaOfInterest, Background, Location) " +
                    "VALUES (@FName, @LName, @Email, @AreaInterest, @Background, @Location)";
                    //"VALUES (@FName, @LName, @Email, @HashPass, @Salt, @AreasIntrest, @Background, @Location)";
                command.Parameters.AddWithValue("@FName", FirstName);
                command.Parameters.AddWithValue("@LName", LastName);
                command.Parameters.AddWithValue("@Email", Email);
                //command.Parameters.AddWithValue("@HashPass", HashPass);
                //command.Parameters.AddWithValue("@Salt", Salt);
                command.Parameters.AddWithValue("@AreaInterest", AreaInterest);
                command.Parameters.AddWithValue("@Background", Background);
                command.Parameters.AddWithValue("@Location", Location);

                connection.Open();
                command.ExecuteNonQuery();
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

        public static void WriteSupervisor(int UserID, string CertNumber, DateTime DateCert, DateTime DateCompletedSupervison, bool DistanceSupervision)
        {
            SqlConnection connection = null;
            try
            {
                //Write supervisor to database
                connection = DataBase.GetConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText =
                           "INSERT INTO " + Schema + ".Supervisors (UserID, CertificationNum, DateCertified, DateCompletedSupervision, DistanceSupervision) " +
                           "VALUES (@UserID, @CertNumber, @DateCert, @DateCompletedSupervison, @DistanceSupervision)";
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@CertNumber", CertNumber);
                command.Parameters.AddWithValue("@DateCert", DateCert);
                command.Parameters.AddWithValue("@DateCompletedSupervison", DateCompletedSupervison);
                if (DistanceSupervision)
                {
                    command.Parameters.AddWithValue("@DistanceSupervision", 1);
                }
                else
                {
                    command.Parameters.AddWithValue("@DistanceSupervision", 0);
                }

                connection.Open();
                command.ExecuteNonQuery();
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

        public static void WriteRelationship(int SupervisorID, int SuperviseeID, DateTime StartDate, DateTime EndDate = new DateTime())
        {
            SqlConnection connection = null;
            try
            {
                //Write supervisor to database
                connection = DataBase.GetConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText =
                    "INSERT INTO " + Schema + ".Relationships (SupervisorID, SuperviseeID, StartDate, EndDate) " +
                    "VALUES (@SupervisorID, @SuperviseeID, @StartDate, @EndDate)";
                command.Parameters.AddWithValue("@SupervisorID", SupervisorID);
                command.Parameters.AddWithValue("@SuperviseeID", SuperviseeID);
                command.Parameters.AddWithValue("@StartDate", StartDate);
                command.Parameters.AddWithValue("@EndDate", EndDate);

                connection.Open();
                command.ExecuteNonQuery();
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

        public static void WriteForms(/*Not sure of all values*/)
        {
            //TODO: implement function
            throw new NotImplementedException();
        }

        public static void WriteFromCompentency(int formID, int CompID)
        {
            //TODO: implement function
            throw new NotImplementedException();
        }

        public static void WriteCompentency(string Title, string Abbreviatio = null, string Description = null)
        {
            //TODO: implement function
            throw new NotImplementedException();
        }

    }
}
