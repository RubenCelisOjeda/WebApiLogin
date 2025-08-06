using ApiLogin.Domain.Entities.Auth.Request;

namespace ApiLogin.Domain.Repository
{
    public interface IAuthRepository
    {
        public Task<bool> SendEmail(string pTableName, string pFieldName, object pValue);
        public Task<string> Login(LoginRequestEntities entities);
    }
}
