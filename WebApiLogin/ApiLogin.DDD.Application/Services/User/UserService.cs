using ApiLogin.DDD.Application.Dto.User.Request.AddUser;
using ApiLogin.DDD.Domain.Entities.User.Request.AddUser;
using ApiLogin.DDD.Domain.Repository;
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
        public async Task<int> AddUser(AddUserRequestDto request)
        {
            try
            {
                //1.Validation
                var mapperRequest = _mapper.Map<AddUserRequestEntities>(request);

                //2.Execution
                var response = await _userRepository.AddUser(mapperRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return 0;
        }
        #endregion
    }
}
