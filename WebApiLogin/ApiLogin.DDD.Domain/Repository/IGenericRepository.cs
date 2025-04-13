namespace ApiLogin.DDD.Domain.Repository
{
    public interface IGenericRepository
    {
        public Task<bool> Exists(string pTableName, string pFieldName, object pValue);
    }
}
