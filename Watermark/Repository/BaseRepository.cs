using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Watermark.Repository
{
    public class BaseRepository : IDisposable
    {
        private string ConnectionString { get; set; }

        private IDbConnection Connection { get; set; }

        public BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (Connection = CreateConnection())
            {
                Connection.Open();
                return Connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        protected IEnumerable<T> Query<T>(string sql, object parameters = null)
        {
            using (Connection = CreateConnection())
            {
                Connection.Open();
                return Connection.Query<T>(sql, parameters);
            }
        }

        protected int Execute(string sql, object parameters = null)
        {
            using (var Connection = CreateConnection())
            {
                Connection.Open();
                return Connection.Execute(sql, parameters);
            }
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
            }
        }
    }
}