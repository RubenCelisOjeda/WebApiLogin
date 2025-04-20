using ApiLogin.Domain.Entities.RecoveryPassword.Request.ExistsCodeEmail;
using ApiLogin.Domain.Entities.RecoveryPassword.Request.ExistsEmail;
using ApiLogin.Domain.Entities.RecoveryPassword.Request.SendCodeEmail;
using ApiLogin.Domain.Repository;
using ApiLogin.Infraestructure.Configuration.Connection;
using Dapper;
using System.Data;

namespace ApiLogin.Infraestructure.Dapper.Repository
{
    public class RecoveryPasswordRepository : IRecoveryPasswordRepository
    {
        #region [Variables]
        private readonly IConnectionFactory _configuration;
        #endregion

        #region [Constructor]
        public RecoveryPasswordRepository(IConnectionFactory configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region [Methods]
        public async Task<bool> SendCodeEmail(SendCodeEmailRequestEntities request)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                const string procedure = @"SELECT [Id], [UserName], [Password], [Email], [DateCreated], [DateModify], [Status]
                                           FROM sis.Usuarios
                                           WHERE Id = @pIdUser";
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    //pIdUser = request.IdUser
                });
                #endregion

                #region [Execute]
                var response = await connection.QueryFirstOrDefaultAsync<bool>(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        public async Task<bool> ExistsCodeEmail(ExistsCodeEmailRequestEntities request)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                const string procedure = @"SELECT [Id], [UserName], [Password], [Email], [DateCreated], [DateModify], [Status]
                                           FROM sis.Usuarios
                                           ORDER BY [Id]  -- Es necesario ordenar para una paginación consistente
                                           OFFSET @Offset ROWS 
                                           FETCH NEXT @PageSize ROWS ONLY";
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    //Offset = (request.PageNumber - 1) * request.PageSize,
                    //PageSize = request.PageSize
                });
                #endregion

                #region [Execute]
                var response = await connection.QueryFirstOrDefaultAsync<bool>(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        public async Task<bool> ExistsEmail(ExistsEmailRequestEntities request)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                const string procedure = @"INSERT INTO sis.Usuarios (UserName, Password, Email, DateCreated, DateModify, Status)
                                           VALUES (@pUserName, @pPassword, @pEmail, GETDATE(), NULL, @pStatus);
                                           SELECT CAST(SCOPE_IDENTITY() AS INT);";
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    //pUserName = request.UserName,
                    //pPassword = request.Password,
                    //pEmail = request.Email,
                    //pStatus = request.Status
                });
                #endregion

                #region [Execute]
                var response = await connection.QueryFirstOrDefaultAsync<bool>(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }
        #endregion
    }
}
