using Dapper;
using Microsoft.AspNetCore.Builder;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Watermark.Repository.DatabaseInitalization;

namespace Watermark.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void SeedWebData(this IApplicationBuilder app)
        {
            SeedApplicationRoles();
            SeedAdminAccounts();
        }

        private static void SeedApplicationRoles()
        {
        }

        private static void SeedAdminAccounts()
        {
        }

        public static void EnsureDbCreated(this IApplicationBuilder app, string server, string databaseName, bool trusted, bool multipleActiveSets)
        {
            var connectionString = $@"Data Source={server};
                                      Initial Catalog={databaseName};
                                      Trusted_Connection={trusted};
                                      MultipleActiveResultSets={multipleActiveSets}";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Dispose();
                    return;
                }
            }

            catch (SqlException)
            {
                DatabaseInitalizationFactory dbFactory = new DatabaseInitalizationFactory();
                dbFactory.CreateDatabase(server, databaseName, trusted, multipleActiveSets);
            }

            catch (Exception e)
            {
                throw new InvalidOperationException($"Database creation failed. See inner exception. ", e);
            }
        }

        public static void MigrateDatabase(this IApplicationBuilder app, string connectionString, string basePath)
        {
            var migrationFilesDir = basePath + "/Repository/Migrations";

            var migrationFiles = Directory.GetFiles(migrationFilesDir);
            var migrationScripts = new Dictionary<int, string>();

            for (var i = 0; i < migrationFiles.Length; i++)
            {
                var script = File.ReadAllText(migrationFiles[i]);
                migrationScripts.Add(i, script);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (var script in migrationScripts.OrderBy(m => m.Key))
                    {
                        connection.Execute(script.Value);
                    }
                }

                finally
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Dispose();
                    }
                }
            }
        }
    }
}