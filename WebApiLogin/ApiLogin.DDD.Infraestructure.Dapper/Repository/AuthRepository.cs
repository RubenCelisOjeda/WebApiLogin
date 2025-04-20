using ApiLogin.Domain.Repository;

namespace ApiLogin.Infraestructure.Dapper.Repository
{
    public class AuthRepository : IAuthRepository
    {
        public Task<bool> SendEmail(string pTableName, string pFieldName, object pValue)
        {
            throw new NotImplementedException();
        }
    }
}
