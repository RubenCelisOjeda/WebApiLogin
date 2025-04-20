using ApiLogin.Application.Dto.Auth.ExistsCodeEmail.Request;
using ApiLogin.Application.Dto.Auth.ExistsEmail.Request;
using ApiLogin.Application.Dto.Auth.SendCodeEmail.Request;
using ApiLogin.Application.Services.RecoveryPassword;
using Microsoft.AspNetCore.Mvc;

namespace ApiLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecoveryPasswordController : BaseController
    {
        #region [Variables]
        private readonly IRecoveryPasswordService _recoveryPasswordService;
        #endregion

        #region [Constructor]
        public RecoveryPasswordController(IRecoveryPasswordService recoveryPasswordService)
        {
            _recoveryPasswordService = recoveryPasswordService;
        }
        #endregion

        #region [Apis]
        [HttpPost]
        [Route("SendCodeEmail")]
        public async Task<IActionResult> SendCodeEmail([FromBody] SendCodeEmailRequestDto request)
        {
            var response = await _recoveryPasswordService.SendCodeEmail(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("ExistsCodeEmail")]
        public async Task<IActionResult> ExistsCodeEmail([FromBody] ExistsCodeEmailRequestDto request)
        {
            var response = await _recoveryPasswordService.ExistsCodeEmail(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("ExistsEmail")]
        public async Task<IActionResult> ExistsEmail([FromBody] ExistsEmailRequestDto request)
        {
            var response = await _recoveryPasswordService.ExistsEmail(request);
            return Ok(response);
        }
        #endregion
    }
}
