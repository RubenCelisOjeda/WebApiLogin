using ApiLogin.Application.Dto.User.Request.AddUser;
using ApiLogin.Application.Dto.User.Request.DeleteUser;
using ApiLogin.Application.Dto.User.Request.GetAllUser;
using ApiLogin.Application.Dto.User.Request.GetUser;
using ApiLogin.Application.Dto.User.Request.UpdateUser;
using ApiLogin.Application.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace ApiLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        #region [Variables]
        private readonly IUserService _userService;
        #endregion

        #region [Constructor]
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region [Apis]

        [HttpPost]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser([FromBody] GetUserRequestDto request)
        {
            var response = await _userService.GetUser(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("GetAllUser")]
        public async Task<IActionResult> GetAllUser([FromBody] GetAllUserRequestDto request)
        {
            var response = await _userService.GetAllUser(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequestDto request)
        {
            var response = await _userService.AddUser(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestDto request)
        {
            var response = await _userService.UpdateUser(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequestDto request)
        {
            var response = await _userService.DeleteUser(request);
            return Ok(response);
        }

        #endregion
    }
}
