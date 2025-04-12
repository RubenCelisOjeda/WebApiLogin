using ApiLogin.DDD.Domain.Entities.User.Request.AddUser;
using ApiLogin.DDD.Domain.Entities.User.Request.DeleteUser;
using ApiLogin.DDD.Domain.Entities.User.Request.GetAllUser;
using ApiLogin.DDD.Domain.Entities.User.Request.GetUser;
using ApiLogin.DDD.Domain.Entities.User.Request.UpdateUser;
using ApiLogin.DDD.Domain.Entities.User.Response.GetAllUser;
using ApiLogin.DDD.Domain.Entities.User.Response.GetUser;

namespace ApiLogin.DDD.Domain.Repository
{
    public interface IUserRepository
    {
        public Task<GetUserResponseEntities> GetUser(GetUserRequestEntities request);
        public Task<IEnumerable<GetAllUserResponseEntities>> GetAllUser(GetAllUserRequestEntities request);
        public Task<int> AddUser(AddUserRequestEntities request);
        public Task<int> UpdateUser(UpdateUserRequestEntities request);
        public Task<int> DeleteUser(DeleteUserRequestEntities request);
    }
}
