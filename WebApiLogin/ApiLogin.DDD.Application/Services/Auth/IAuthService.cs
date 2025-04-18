using ApiLogin.DDD.Application.Dto.Auth.ExistsCodeEmail.Request;
using ApiLogin.DDD.Application.Dto.Auth.ExistsCodeEmail.Response;
using ApiLogin.DDD.Application.Dto.Auth.ExistsEmail.Request;
using ApiLogin.DDD.Application.Dto.Auth.ExistsEmail.Response;
using ApiLogin.DDD.Application.Dto.Auth.SendCodeEmail.Request;
using ApiLogin.DDD.Application.Dto.Auth.SendCodeEmail.Response;
using ApiLogin.DDD.Transversal.Utils;

namespace ApiLogin.DDD.Application.Services.Auth
{
    public interface IAuthService
    {
        public Task<BaseResponse<SendCodeEmailResponseDto>> SendCodeEmail(SendCodeEmailRequestDto request);
        public Task<BaseResponse<ExistsCodeEmailResponseDto>> ExistsCodeEmail(ExistsCodeEmailRequestDto request);
        public Task<BaseResponse<ExistsEmailResponseDto>> ExistsEmail(ExistsEmailRequestDto request);
    }
}
