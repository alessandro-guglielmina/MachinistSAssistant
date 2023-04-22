using Microsoft.Data.Sqlite;
using System.Data;

namespace MachinistSAssistant.Data
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _dbEngine;
        private readonly string _connectionString;

        public DbConnectionFactory(string dbEngine, string connectionString)
        {
            _connectionString = connectionString;
            _dbEngine = dbEngine;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            switch (_dbEngine)
            {
                case "sqlite":
                    var connection = new SqliteConnection(_connectionString);
                    await connection.OpenAsync();
                    return connection;
                default:
                    throw new NotImplementedException(); ;
            }
        }
    }
}