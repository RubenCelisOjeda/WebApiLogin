using ApiLogin.DDD.Application.Dto.User.Request.AddUser;
using ApiLogin.DDD.Application.Services.User;
using ApiLogin.DDD.Transversal.Utils;
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
        public UserController( UserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region [Apis]
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            BaseResponse<object> response = null;
             _userService.AddUser();
            return Ok(response);
        }

        //[HttpPost]
        //[Route("UpdateUser")]
        //public async Task<IActionResult> UpdateUser([FromBody] AuthRequest pEntidad)
        //{
        //    BaseResponse<object> responseData = null;

        //    //var responseData = await _managerService.ExistsEmail(email);
        //    //return Ok(responseData);
        //}

        //[HttpPost]
        //[Route("DeleteUser")]
        //public async Task<IActionResult> UpdateUser([FromBody] AuthRequest pEntidad)
        //{
        //    BaseResponse<object> responseData = null;

        //    //var responseData = await _managerService.ExistsEmail(email);
        //    //return Ok(responseData);
        //}
        #endregion
    }
}
