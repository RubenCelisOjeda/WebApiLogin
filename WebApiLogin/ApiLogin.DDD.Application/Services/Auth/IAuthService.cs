using ApiLogin.Application.Dto.Auth.Login.Request;
using ApiLogin.DDD.Transversal.Utils;

namespace ApiLogin.Application.Services.Auth
{
    public interface IAuthService
    {
        public Task<BaseResponse<bool>> Login(LoginRequestDto request);
    }
}
