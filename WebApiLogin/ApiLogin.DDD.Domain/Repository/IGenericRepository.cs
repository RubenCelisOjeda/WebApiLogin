using ApiLogin.Domain.Entities.Generic.Request.AddSession;

namespace ApiLogin.Domain.Repository
{
    public interface IGenericRepository
    {
        public Task<bool> Exists(string pTableName, string pFieldName, object pValue);
        public Task<bool> Exists(string pTableName, string pFieldName, object pValue,int IdUser);
        public Task<int> AddSession(AddSessionRequestEntities request);
    }
}
