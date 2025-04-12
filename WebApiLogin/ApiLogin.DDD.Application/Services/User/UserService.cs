using ApiLogin.DDD.Application.Dto.User.Request.AddUser;
using ApiLogin.DDD.Application.Dto.User.Request.DeleteUser;
using ApiLogin.DDD.Application.Dto.User.Request.GetAllUser;
using ApiLogin.DDD.Application.Dto.User.Request.GetUser;
using ApiLogin.DDD.Application.Dto.User.Request.UpdateUser;
using ApiLogin.DDD.Application.Dto.User.Response.Base.GetAllUser;
using ApiLogin.DDD.Application.Dto.User.Response.Base.GetUser;
using ApiLogin.DDD.Domain.Entities.User.Request.AddUser;
using ApiLogin.DDD.Domain.Entities.User.Request.DeleteUser;
using ApiLogin.DDD.Domain.Entities.User.Request.GetAllUser;
using ApiLogin.DDD.Domain.Entities.User.Request.GetUser;
using ApiLogin.DDD.Domain.Entities.User.Request.UpdateUser;
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
        public async Task<BaseResponse<GetUserResponseDto>> GetUser(GetUserRequestDto request)
        {
            BaseResponse<GetUserResponseDto> baseResponse = null;

            try
            {
                //1 mapper request
                var mapperRequest = _mapper.Map<GetUserRequestEntities>(request);

                //2 response
                var response = await _userRepository.GetUser(mapperRequest);

                //3 mapper response
                var mapperResponse = _mapper.Map<GetUserResponseDto>(response);

                if (mapperResponse is not null)
                    baseResponse = BaseResponse<GetUserResponseDto>.BaseResponseSuccess(mapperResponse);
                else
                    baseResponse = BaseResponse<GetUserResponseDto>.BaseResponseWarning(mapperResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<GetUserResponseDto>.BaseResponseError(ex.Message);
            }
            return baseResponse;
        }

        public async Task<BaseResponse<IEnumerable<GetAllUserResponseDto>>> GetAllUser(GetAllUserRequestDto request)
        {
            BaseResponse<IEnumerable<GetAllUserResponseDto>> baseResponse = null;

            try
            {
                //1 mapper request
                var mapperRequest = _mapper.Map<GetAllUserRequestEntities>(request);

                //2 response
                var response = await _userRepository.GetAllUser(mapperRequest);

                //3 mapper response
                var mapperResponse = _mapper.Map<IEnumerable<GetAllUserResponseDto>>(response);

                if (response.Count() > 0)
                    baseResponse = BaseResponse<IEnumerable<GetAllUserResponseDto>>.BaseResponseSuccess(mapperResponse);
                else
                    baseResponse = BaseResponse<IEnumerable<GetAllUserResponseDto>>.BaseResponseWarning(mapperResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                baseResponse = BaseResponse<IEnumerable<GetAllUserResponseDto>>.BaseResponseError(ex.Message);
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

        public async Task<BaseResponse<int>> UpdateUser(UpdateUserRequestDto request)
        {
            BaseResponse<int> baseResponse = null;

            try
            {
                var mapperRequest = _mapper.Map<UpdateUserRequestEntities>(request);

                var response = await _userRepository.UpdateUser(mapperRequest);

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

        public async Task<BaseResponse<int>> DeleteUser(DeleteUserRequestDto request)
        {
            BaseResponse<int> baseResponse = null;

            try
            {
                var mapperRequest = _mapper.Map<DeleteUserRequestEntities>(request);

                var response = await _userRepository.DeleteUser(mapperRequest);

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
