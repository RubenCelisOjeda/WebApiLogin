using Microsoft.AspNetCore.Mvc;

namespace ApiLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        #region [Variables]
        private readonly ILogger<UserController> _logger;
        //private readonly IAuthService _authService;
        #endregion

        #region [Constructor]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="authService"></param>
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            //_authService = authService;
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

        //[HttpPost]
        //[Route("AddUser")]
        //public async Task<IActionResult> AddUser([FromBody] AuthRequest pEntidad)
        //{
        //    BaseResponse<object> responseData = null;

        //    //var responseData = await _managerService.ExistsEmail(email);
        //    //return Ok(responseData);
        //}

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
