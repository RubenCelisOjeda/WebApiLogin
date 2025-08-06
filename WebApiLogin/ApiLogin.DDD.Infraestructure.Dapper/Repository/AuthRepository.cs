using ApiLogin.Domain.Entities.Auth.Request;
using ApiLogin.Domain.Repository;
using ApiLogin.Infraestructure.Configuration.Connection;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ApiLogin.Infraestructure.Dapper.Repository
{
    public class AuthRepository : IAuthRepository
    {
        #region [Variables]
        private readonly IConnectionFactory _configuration;
        #endregion

        #region [Constructor]
        public AuthRepository(IConnectionFactory configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region [Methods]
        public async Task<string> Login(LoginRequestEntities request)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                const string procedure = @"SELECT Password FROM sis.Usuarios WHERE Email = @pEmail";
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    pEmail = request.Email
                });
                #endregion

                #region [Execute]
                var response = await connection.QueryFirstOrDefaultAsync<string>(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        public Task<bool> SendEmail(string pTableName, string pFieldName, object pValue)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
