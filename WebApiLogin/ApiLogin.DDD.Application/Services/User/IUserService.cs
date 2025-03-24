using ApiLogin.DDD.Application.Dto.User.Request.AddUser;

namespace ApiLogin.DDD.Application.Services.User
{
    public interface IUserService
    {
        public Task<int> AddUser(AddUserRequestDto request);
    }
}
