using ApiLogin.DDD.Domain.Repository;

namespace ApiLogin.DDD.Infraestructure.Dapper.Repository
{
    public class AuthRepository : IAuthRepository
    {
        public Task<bool> SendEmail(string pTableName, string pFieldName, object pValue)
        {
            throw new NotImplementedException();
        }
    }
}
