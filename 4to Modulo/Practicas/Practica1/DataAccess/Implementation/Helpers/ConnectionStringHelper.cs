using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess.Implementation.Helpers
{
    public class ConnectionStringHelper
    {
        public static void OpenSqlConnectionInCode()
        {
            string connectionString = GetConnStringFromConfigFile();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString From Code: {0}",
                    connection.ConnectionString);

            }
        }

        //public static string GetConnStringFromCode()
        //{
        //    return "Data Source = STKEND13944\\SQLEXPRESS; Initial Catalog = SurveyDB; User Id=sa; Password=softtek.001";
        //}

        public static string GetConnStringFromConfigFile()
        {
            return ConfigurationManager.ConnectionStrings["SQLExpress"].ConnectionString;
        }

    }
}
