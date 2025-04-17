using ApiLogin.DDD.Application.Dto.User.Request.GetUser;
using ApiLogin.DDD.Application.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace ApiLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        #region [Variables]
        private readonly IUserService _userService;
        #endregion

        #region [Constructor]
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region [Apis]

        [HttpPost]
        [Route("RecoveryPassword")]
        public async Task<IActionResult> RecoveryPassword([FromBody] GetUserRequestDto request)
        {
            var response = await _userService.GetUser(request);
            return Ok(response);
        }

        #endregion
    }
}
