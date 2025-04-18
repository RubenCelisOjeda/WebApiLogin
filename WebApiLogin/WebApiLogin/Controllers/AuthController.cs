using ApiLogin.DDD.Application.Dto.Auth.ExistsCodeEmail.Request;
using ApiLogin.DDD.Application.Dto.Auth.ExistsEmail.Request;
using ApiLogin.DDD.Application.Dto.Auth.SendCodeEmail.Request;
using ApiLogin.DDD.Application.Services.Auth;
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
        [Route("SendCodeEmail")]
        public async Task<IActionResult> SendCodeEmail([FromBody] SendCodeEmailRequestDto request)
        {
            var response = await _authService.GetUser(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("ExistsCodeEmail")]
        public async Task<IActionResult> ExistsCodeEmail([FromBody] ExistsCodeEmailRequestDto request)
        {
            var response = await _authService.GetUser(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("ExistsEmail")]
        public async Task<IActionResult> ExistsEmail([FromBody] ExistsEmailRequestDto request)
        {
            var response = await _authService.GetUser(request);
            return Ok(response);
        }

        #endregion
    }
}
