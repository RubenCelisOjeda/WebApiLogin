namespace ApiLogin.DDD.Domain.Repository
{
    public interface IAuthRepository
    {
        public Task<bool> SendEmail(string pTableName, string pFieldName, object pValue);
    }
}
