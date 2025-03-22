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
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        #endregion

        #region [Constructor]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="authService"></param>
        public UserController(ILogger<UserController> logger , UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        #endregion

        #region [Apis]
        //[HttpGet]
        //[Route("GetUser")]
        //public async Task<IActionResult> GetUser([FromBody] AuthRequest pEntidad)
        //{
        //    BaseResponse<object> responseData = null;

        //    //var responseData = await _managerService.ExistsEmail(email);
        //    //return Ok(responseData);
        //}

        //[HttpPost]
        //[Route("GetAllUser")]
        //public async Task<IActionResult> GetAllUser([FromBody] AuthRequest pEntidad)
        //{
        //    BaseResponse<object> responseData = null;

        //    //var responseData = await _managerService.ExistsEmail(email);
        //    //return Ok(responseData);
        //}

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
