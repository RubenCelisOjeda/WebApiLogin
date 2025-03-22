using ApiLogin.DDD.Domain.Repository;

namespace ApiLogin.DDD.Application.Services.User
{
    /// <summary>
    /// User Service
    /// </summary>
    public class UserService : IUserService
    {
        #region [Variables]
        private readonly IUserRepository _userRepository;
        #endregion

        #region [Constructor]
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region [Methods]
        public void AddUser()
        {
            _userRepository.AddUser();
        }
        #endregion
    }
}
