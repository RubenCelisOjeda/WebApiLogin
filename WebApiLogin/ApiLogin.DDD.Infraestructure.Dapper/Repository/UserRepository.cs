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

        public void AddUser()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region [Methods]
        public async Task AddUser(AuthRequest pEntidad)
        {
            using (var connection = _configuration.GetConnectionSeguridad)
            {
                #region [Query]
                const string procedure = @"SELECT usu.Id AS ID,
                                                  usu.UserName AS USERNAME,
                                                  usu.Email AS EMAIL

                                           FROM Usuario usu
                                           WHERE usu.Email = @pEmail";
                #endregion

                #region [Parameters]
                var parameters = new DynamicParameters(new
                {
                    pEmail = pEntidad.Usuario,
                    pPassword = pEntidad.Password
                });
                #endregion

                #region [Execute]
                var response = await connection.QueryAsync<AuthResponse>(procedure, parameters, commandType: CommandType.Text);
                return response.FirstOrDefault();
                #endregion
            }
        }
        #endregion
    }
}
