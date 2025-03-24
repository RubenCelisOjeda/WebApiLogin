using ApiLogin.DDD.Domain.Entities.User.Request.AddUser;
using ApiLogin.DDD.Domain.Entities.User.Response.AddUser;

namespace ApiLogin.DDD.Domain.Repository
{
    public interface IUserRepository
    {
        public Task<int> AddUser(AddUserRequestEntities request);
    }
}
