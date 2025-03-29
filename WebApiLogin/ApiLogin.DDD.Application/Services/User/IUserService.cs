using ApiLogin.DDD.Application.Dto.User.Request.AddUser;
using ApiLogin.DDD.Transversal.Utils;

namespace ApiLogin.DDD.Application.Services.User
{
    public interface IUserService
    {
        public Task<BaseResponse<int>> AddUser(AddUserRequestDto request);
    }
}
