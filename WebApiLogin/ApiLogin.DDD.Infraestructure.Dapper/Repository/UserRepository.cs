using ApiLogin.DDD.Domain.Entities.User.Request.AddUser;
using ApiLogin.DDD.Domain.Entities.User.Request.DeleteUser;
using ApiLogin.DDD.Domain.Entities.User.Request.GetAllUser;
using ApiLogin.DDD.Domain.Entities.User.Request.GetUser;
using ApiLogin.DDD.Domain.Entities.User.Request.UpdateUser;
using ApiLogin.DDD.Domain.Entities.User.Response.GetAllUser;
using ApiLogin.DDD.Domain.Entities.User.Response.GetUser;
using ApiLogin.DDD.Infraestructure.Configuration.Connection;
using Dapper;
using System.Data;

namespace ApiLogin.DDD.Infraestructure.Dapper.Repository
{
    public class UserRepository : AuthRepository
    {
        #region [Variables]
        private readonly IConnectionFactory _configuration;
        #endregion

        #region [Constructor]
        public UserRepository(IConnectionFactory configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region [Methods]
        public async Task<GetUserResponseEntities> GetUser(GetUserRequestEntities request)
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
                    pIdUser = request.IdUser
                });
                #endregion

                #region [Execute]
                var response = await connection.QueryFirstOrDefaultAsync<GetUserResponseEntities>(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        public async Task<IEnumerable<GetAllUserResponseEntities>> GetAllUser(GetAllUserRequestEntities request)
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
                    Offset = (request.PageNumber - 1) * request.PageSize,
                    PageSize = request.PageSize
                });
                #endregion

                #region [Execute]
                var response = await connection.QueryAsync<GetAllUserResponseEntities>(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        public async Task<int> AddUser(AddUserRequestEntities request)
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
                    pUserName = request.UserName,
                    pPassword = request.Password,
                    pEmail = request.Email,
                    pStatus = request.Status
                });
                #endregion

                #region [Execute]
                var response = await connection.ExecuteScalarAsync<int>(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        public async Task<int> UpdateUser(UpdateUserRequestEntities request)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                const string procedure = @"UPDATE sis.Usuarios SET UserName = @pUserName,
                                                                   Password = @pPassword,
                                                                   DateModify = @pDateModify,
                                                                   Status = @pStatus

                                                               WHERE Id = @pIdUser";
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    pIdUser = request.IdUser,
                    pUserName = request.UserName,
                    pPassword = request.Password,
                    pDateModify = request.DateModify,
                    pEmail = request.Email,
                    pStatus = request.Status
                });
                #endregion

                #region [Execute]
                var response = await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        public async Task<int> DeleteUser(DeleteUserRequestEntities request)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                const string procedure = @"DELETE FROM sis.Usuarios WHERE Id = @pIdUser";
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    pIdUser = request.IdUser
                });
                #endregion

                #region [Execute]
                var response = await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }
        #endregion
    }
}