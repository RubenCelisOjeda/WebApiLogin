using ApiLogin.DDD.Application.Dto.User.Request.AddUser;
using ApiLogin.DDD.Domain.Entities.User.Request.AddUser;
using ApiLogin.DDD.Domain.Repository;
using ApiLogin.DDD.Transversal.Utils;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace ApiLogin.DDD.Application.Services.User
{
    public class UserService : IUserService
    {
        #region [Variables]
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        #endregion

        #region [Constructor]
        public UserService(ILogger<UserService> logger, IMapper mapper, IUserRepository userRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        #endregion

        #region [Methods]
        public async Task<BaseResponse<int>> AddUser(AddUserRequestDto request)
        {
            BaseResponse<int> baseResponse = null;

            try
            {
                var mapperRequest = _mapper.Map<AddUserRequestEntities>(request);

                var response = await _userRepository.AddUser(mapperRequest);

                if (response > 0)
                    baseResponse = BaseResponse<int>.BaseResponseSuccess(response);
                else
                    baseResponse = BaseResponse<int>.BaseResponseWarning(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<int>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        public async Task<BaseResponse<int>> AddUser(AddUserRequestDto request)
        {
            BaseResponse<int> baseResponse = null;

            try
            {
                var mapperRequest = _mapper.Map<AddUserRequestEntities>(request);

                var response = await _userRepository.AddUser(mapperRequest);

                if (response > 0)
                    baseResponse = BaseResponse<int>.BaseResponseSuccess(response);
                else
                    baseResponse = BaseResponse<int>.BaseResponseWarning(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<int>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        public async Task<BaseResponse<int>> AddUser(AddUserRequestDto request)
        {
            BaseResponse<int> baseResponse = null;

            try
            {
                var mapperRequest = _mapper.Map<AddUserRequestEntities>(request);

                var response = await _userRepository.AddUser(mapperRequest);

                if (response > 0)
                    baseResponse = BaseResponse<int>.BaseResponseSuccess(response);
                else
                    baseResponse = BaseResponse<int>.BaseResponseWarning(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<int>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        public async Task<BaseResponse<int>> AddUser(AddUserRequestDto request)
        {
            BaseResponse<int> baseResponse = null;

            try
            {
                var mapperRequest = _mapper.Map<AddUserRequestEntities>(request);

                var response = await _userRepository.AddUser(mapperRequest);

                if (response > 0)
                    baseResponse = BaseResponse<int>.BaseResponseSuccess(response);
                else
                    baseResponse = BaseResponse<int>.BaseResponseWarning(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<int>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        public async Task<BaseResponse<int>> AddUser(AddUserRequestDto request)
        {
            BaseResponse<int> baseResponse = null;

            try
            {
                var mapperRequest = _mapper.Map<AddUserRequestEntities>(request);

                var response = await _userRepository.AddUser(mapperRequest);

                if (response > 0)
                    baseResponse = BaseResponse<int>.BaseResponseSuccess(response);
                else
                    baseResponse = BaseResponse<int>.BaseResponseWarning(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<int>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }
        #endregion
    }
}
