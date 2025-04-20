using ApiLogin.Application.Services.User;
using ApiLogin.Domain.Repository;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace ApiLogin.Application.Services.Auth
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

        #endregion
    }
}
