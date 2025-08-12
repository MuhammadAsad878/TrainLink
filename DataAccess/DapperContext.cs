using Microsoft.Data.SqlClient;
using System.Data;

namespace TrainLink.DataAccess
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connectionString = _configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Database connection string is missing in appsettings.json.");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
