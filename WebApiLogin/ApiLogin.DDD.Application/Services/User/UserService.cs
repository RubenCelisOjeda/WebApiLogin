using ApiLogin.DDD.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace ApiLogin.DDD.Application.Services.User
{
    /// <summary>
    /// User Service
    /// </summary>
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
        public void AddUser()
        {
            try
            {
                _userRepository.AddUser();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        #endregion
    }
}
