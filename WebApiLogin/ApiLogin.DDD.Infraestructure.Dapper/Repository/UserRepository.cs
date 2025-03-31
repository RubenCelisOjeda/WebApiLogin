using ApiLogin.DDD.Domain.Entities.User.Request.AddUser;
using ApiLogin.DDD.Domain.Entities.User.Request.DeleteUser;
using ApiLogin.DDD.Domain.Entities.User.Request.GetAllUser;
using ApiLogin.DDD.Domain.Entities.User.Request.GetUser;
using ApiLogin.DDD.Domain.Entities.User.Request.UpdateUser;
using ApiLogin.DDD.Domain.Repository;
using ApiLogin.DDD.Infraestructure.Configuration.Connection;
using Dapper;
using System.Data;

namespace ApiLogin.DDD.Infraestructure.Dapper.Repository
{
    public class UserRepository : IUserRepository
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
        public async Task<int> GetUser(GetUserRequestEntities request)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                const string procedure = @"INSERT INTO sis.Usuarios (UserName, Password, Email, DateCreated, DateModify, Status)
                                           VALUES (@pUserName, @pPassword, @pEmail, GETDATE(), NULL, @pStatus);";
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
                var response = await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        public async Task<int> GetAllUser(GetAllUserRequestEntities request)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                const string procedure = @"INSERT INTO sis.Usuarios (UserName, Password, Email, DateCreated, DateModify, Status)
                                           VALUES (@pUserName, @pPassword, @pEmail, GETDATE(), NULL, @pStatus);";
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
                var response = await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.Text);
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
                                           VALUES (@pUserName, @pPassword, @pEmail, GETDATE(), NULL, @pStatus);";
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
                var response = await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }

        public async Task<int> UpdateUser(UpdateUserRequestEntities request)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                const string procedure = @"INSERT INTO sis.Usuarios (UserName, Password, Email, DateCreated, DateModify, Status)
                                           VALUES (@pUserName, @pPassword, @pEmail, GETDATE(), NULL, @pStatus);";
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
                const string procedure = @"INSERT INTO sis.Usuarios (UserName, Password, Email, DateCreated, DateModify, Status)
                                           VALUES (@pUserName, @pPassword, @pEmail, GETDATE(), NULL, @pStatus);";
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
                var response = await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.Text);
                return response;
                #endregion
            }
        }
        #endregion
    }
}