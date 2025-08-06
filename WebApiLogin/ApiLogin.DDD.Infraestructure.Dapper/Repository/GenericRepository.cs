using ApiLogin.Domain.Entities.Generic.Request.AddSession;
using ApiLogin.Domain.Repository;
using ApiLogin.Infraestructure.Configuration.Connection;
using Dapper;
using System.Data;

namespace ApiLogin.Infraestructure.Dapper.Repository
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
                    pValue
                });
                #endregion

                #region [Execute]
                var response = await connection.ExecuteScalarAsync<int>(query, parameters, commandType: CommandType.Text);
                return response > 0;
                #endregion
            }
        }

        public async Task<string> GetField(string pTableName, string pFieldName, object pValue,string pColumnName)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                string query = string.Format("SELECT {0} FROM sis.{1} WHERE {2} = @pValue", pColumnName,pTableName, pFieldName);
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    pValue
                });
                #endregion

                #region [Execute]
                var response = await connection.QueryFirstOrDefaultAsync<string>(query, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        public async Task<bool> Exists(string pTableName, string pFieldName, object pValue, int pIdUser)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                string query = string.Format("SELECT COUNT(1) FROM sis.{0} WHERE {1} = @pValue AND Id = @pIdUser", pTableName, pFieldName);
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    pValue,
                    pIdUser
                });
                #endregion

                #region [Execute]
                var response = await connection.ExecuteScalarAsync<int>(query, parameters, commandType: CommandType.Text);
                return response > 0;
                #endregion
            }
        }

        public async Task<int> AddSession(AddSessionRequestEntities request)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                const string query = @"INSERT INTO sis.Sessions (Email,CodeGenerated,DateCreated,DateModify,Status)
                                                         VALUES (@pEmail,@pCodeGenerated,GETDATE(),NULL,1)";
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    pEmail = request.Email,
                    pCodeGenerated = request.CodeGenerated
                });
                #endregion

                #region [Execute]
                var response = await connection.ExecuteScalarAsync<int>(query, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }
        #endregion
    }
}
