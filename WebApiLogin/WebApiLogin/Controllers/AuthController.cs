using ApiLogin.Application.Dto.Auth.Login.Request;
using ApiLogin.Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ApiLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        #region [Variables]
        private readonly IAuthService _authService;
        #endregion

        #region [Constructor]
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        #endregion

        #region [Apis]

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var response = await _authService.Login(request);
            return Ok(response);
        }

        #endregion
    }
}
