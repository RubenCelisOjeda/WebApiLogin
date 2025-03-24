using ApiLogin.DDD.Application.Dto.User.Request.AddUser;
using ApiLogin.DDD.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace ApiLogin.DDD.Application.Services.User
{
    public class UserService : IUserService
    {
        #region [Variables]
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        #endregion

        #region [Constructor]
        public UserService(ILogger<UserService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        #endregion

        #region [Methods]
        public async Task<int> AddUser(AddUserRequestDto request)
        {
            try
            {
                //1.Validation

                //2.Execution
                var response = await _userRepository.AddUser(null);

                //3.Response

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
