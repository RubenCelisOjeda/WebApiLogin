using ApiLogin.DDD.Domain.Repository;

namespace ApiLogin.DDD.Application.Services
{
    /// <summary>
    /// User Service
    /// </summary>
    public class UserService
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
        public void AddProduct(string name, decimal price)
        {

            _userRepository.AddUser();
        }
        #endregion
    }
}
