using ApiLogin.DDD.Application.Dto.Auth.ExistsCodeEmail.Request;
using ApiLogin.DDD.Application.Dto.Auth.ExistsCodeEmail.Response;
using ApiLogin.DDD.Application.Dto.Auth.ExistsEmail.Request;
using ApiLogin.DDD.Application.Dto.Auth.ExistsEmail.Response;
using ApiLogin.DDD.Application.Dto.Auth.SendCodeEmail.Request;
using ApiLogin.DDD.Application.Dto.Auth.SendCodeEmail.Response;
using ApiLogin.DDD.Application.Dto.User.Request.GetUser;
using ApiLogin.DDD.Application.Dto.User.Response.Base.GetUser;
using ApiLogin.DDD.Application.Services.User;
using ApiLogin.DDD.Domain.Entities.User.Request.GetUser;
using ApiLogin.DDD.Domain.Repository;
using ApiLogin.DDD.Transversal.Utils;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace ApiLogin.DDD.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        #region [Variables]
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        private readonly IGenericRepository _genericRepository;
        #endregion

        #region [Constructor]
        public AuthService(ILogger<UserService> logger, IMapper mapper, IAuthRepository authRepository, IGenericRepository genericRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _authRepository = authRepository;
            _genericRepository = genericRepository;
        }
        #endregion

        #region [Methods]
        public async Task<BaseResponse<SendCodeEmailResponseDto>> SendCodeEmail(SendCodeEmailRequestDto request)
        {
            BaseResponse<SendCodeEmailResponseDto> baseResponse = null;

            try
            {
                //1 mapper request
                var mapperRequest = _mapper.Map<GetUserRequestEntities>(request);

                //2 response
                var response = await _authRepository.SendEmail(mapperRequest);

                //3 mapper response
                var mapperResponse = _mapper.Map<GetUserResponseDto>(response);

                if (mapperResponse is not null)
                    baseResponse = BaseResponse<SendCodeEmailResponseDto>.BaseResponseSuccess(mapperResponse);
                else
                    baseResponse = BaseResponse<SendCodeEmailResponseDto>.BaseResponseWarning(mapperResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<SendCodeEmailResponseDto>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        public async Task<BaseResponse<SendCodeEmailResponseDto>> ExistsCodeEmail(SendCodeEmailRequestDto request)
        {
            BaseResponse<SendCodeEmailResponseDto> baseResponse = null;

            try
            {
                //1 mapper request
                var mapperRequest = _mapper.Map<GetUserRequestEntities>(request);

                //2 response
                var response = await _authRepository.SendEmail(mapperRequest);

                //3 mapper response
                var mapperResponse = _mapper.Map<GetUserResponseDto>(response);

                if (mapperResponse is not null)
                    baseResponse = BaseResponse<SendCodeEmailResponseDto>.BaseResponseSuccess(mapperResponse);
                else
                    baseResponse = BaseResponse<SendCodeEmailResponseDto>.BaseResponseWarning(mapperResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<SendCodeEmailResponseDto>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        public async Task<BaseResponse<SendCodeEmailResponseDto>> ExistsEmail(SendCodeEmailRequestDto request)
        {
            BaseResponse<SendCodeEmailResponseDto> baseResponse = null;

            try
            {
                //1 mapper request
                var mapperRequest = _mapper.Map<GetUserRequestEntities>(request);

                //2 response
                var response = await _authRepository.SendEmail(mapperRequest);

                //3 mapper response
                var mapperResponse = _mapper.Map<GetUserResponseDto>(response);

                if (mapperResponse is not null)
                    baseResponse = BaseResponse<SendCodeEmailResponseDto>.BaseResponseSuccess(mapperResponse);
                else
                    baseResponse = BaseResponse<SendCodeEmailResponseDto>.BaseResponseWarning(mapperResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<SendCodeEmailResponseDto>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        #endregion
    }
}
