using System;
using System.Data;
using System.Data.SqlClient;

namespace Simpl.Core.Databases
{
    public class SqlDatabase : IDatabase
    {
        private string _connectionString;
        public SqlDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection OpenConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
