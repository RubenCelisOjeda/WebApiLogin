using ApiLogin.DDD.Domain.Entities.User.Request.GetUser;
using ApiLogin.DDD.Domain.Entities.User.Response.GetUser;
using ApiLogin.DDD.Domain.Repository;
using ApiLogin.DDD.Infraestructure.Configuration.Connection;
using Dapper;
using System.Data;

namespace ApiLogin.DDD.Infraestructure.Dapper.Repository
{
    public class GenericRepository : IGenericRepository
    {
        #region [Variables]
        private readonly IConnectionFactory _configuration;
        #endregion

        #region [Constructor]
        public GenericRepository(IConnectionFactory configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region [Methods]
        public async Task<bool> Exists(string pTableName, string pFieldName, object pValue)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                string query = string.Format("SELECT COUNT(1) FROM sis.{0} WHERE {1} = @pValue", pTableName, pFieldName);
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    pValue = pValue,
                });
                #endregion

                #region [Execute]
                var response = await connection.ExecuteScalarAsync<int>(query, parameters, commandType: CommandType.Text);
                return response > 0;
                #endregion
            }
        }
        #endregion
    }
}
