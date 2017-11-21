using System.Data;
using System.Data.SqlClient;

namespace Watermark.Repository.DatabaseInitalization
{
    public class DatabaseInitalizationFactory : IDatabaseInitalizationFactory
    {
        public void CreateDatabase(string server, string databaseName, bool trustedConnection = true, bool multipleActiveResultSets = true)
        {
            var connectionString = $@"Data Source={server};
                                      Trusted_Connection={trustedConnection};
                                      MultipleActiveResultSets={multipleActiveResultSets}";

            using (var connection = new SqlConnection(connectionString))
            {
                var str = $"CREATE DATABASE {databaseName} ON PRIMARY " +
                          $"(NAME = {databaseName}_Data, " +
                          $"FILENAME = 'C:\\Watermark\\{databaseName}Data.mdf', " +
                          "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                          $"LOG ON (NAME = {databaseName}_Log, " +
                          $"FILENAME = 'C:\\Watermark\\{databaseName}.ldf', " +
                          "SIZE = 1MB, " +
                          "MAXSIZE = 5MB, " +
                          "FILEGROWTH = 10%)";

                SqlCommand myCommand = new SqlCommand(str, connection);
                try
                {
                    connection.Open();
                    myCommand.ExecuteNonQuery();
                }

                catch (SqlException e)
                {

                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

        }
    }
}