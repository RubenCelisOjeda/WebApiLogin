using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace ApiLogin.DDD.Infraestructure.Configuration.Connection
{
    public class ConnectionFactory : IConnectionFactory
    {
        #region [Properties]
        private readonly IConfiguration _configuration;
        private readonly ILogger<ConnectionFactory> _logger;
        #endregion

        #region [Constructor]
        public ConnectionFactory(IConfiguration configuration, ILogger<ConnectionFactory> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        #endregion

        #region [Interfaces]
        public IDbConnection GetConnectionSeguridad
        {
            get { return GetConnection(_configuration.GetConnectionString("DB_Login")); }
        }
        #endregion

        #region [Methods]

        public IDbConnection GetConnection(string pDataBase)
        {
            var connection = new SqlConnection();

            if (connection == null) return null;

            connection.ConnectionString = pDataBase;
            connection.Open();

            return connection;
        }
        #endregion
    }
}
