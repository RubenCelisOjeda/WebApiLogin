using ApiLogin.Application.Dto.Auth.ExistsCodeEmail.Request;
using ApiLogin.Application.Dto.Auth.ExistsEmail.Request;
using ApiLogin.Application.Dto.Auth.SendCodeEmail.Request;
using ApiLogin.DDD.Transversal.Utils;

namespace ApiLogin.Application.Services.RecoveryPassword
{
    public interface IRecoveryPasswordService
    {
        public Task<BaseResponse<bool>> SendCodeEmail(SendCodeEmailRequestDto request);
        public Task<BaseResponse<bool>> ExistsCodeEmail(ExistsCodeEmailRequestDto request);
        public Task<BaseResponse<bool>> ExistsEmail(ExistsEmailRequestDto request);
    }
}
