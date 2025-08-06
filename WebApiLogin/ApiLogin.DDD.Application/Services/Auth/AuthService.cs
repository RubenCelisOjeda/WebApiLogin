using ApiLogin.Application.Dto.Auth.Login.Request;
using ApiLogin.DDD.Transversal.Common;
using ApiLogin.DDD.Transversal.Utils;
using ApiLogin.Domain.Entities.Auth.Request;
using ApiLogin.Domain.Repository;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace ApiLogin.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        #region [Variables]
        private readonly ILogger<AuthService> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        private readonly IGenericRepository _genericRepository;
        #endregion

        #region [Constructor]
        public AuthService(ILogger<AuthService> logger, IMapper mapper, IAuthRepository authRepository, IGenericRepository genericRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _authRepository = authRepository;
            _genericRepository = genericRepository;
        }

        public async Task<BaseResponse<bool>> Login(LoginRequestDto request)
        {
            BaseResponse<bool> baseResponse = null;

            try
            {
                #region [Validations]
                var isValidEmail = await _genericRepository.Exists("Usuarios", "Email", request.Email);
                if (!isValidEmail)
                {
                    baseResponse = BaseResponse<bool>.BaseResponseWarning(isValidEmail, Constant.ResponseMessage.LoginInvalid);
                    return baseResponse;
                }

                // Mapper request
                var mapperRequest = _mapper.Map<LoginRequestEntities>(request);
                var passwordHash = await _authRepository.Login(mapperRequest);
                var isValidPassword = MetGlo.VerifyPassword(request.Password, passwordHash);

                #endregion
                if (isValidPassword)
                    baseResponse = BaseResponse<bool>.BaseResponseSuccess(isValidPassword);
                else
                    baseResponse = BaseResponse<bool>.BaseResponseWarning(isValidPassword,Constant.ResponseMessage.LoginInvalid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<bool>.BaseResponseError(ex.Message);
            }

            return baseResponse;
        }
        #endregion

        #region [Methods]

        #endregion
    }
}
