namespace ApiLogin.XUnit
{
    public class UserControllerTest
    {
        //private readonly Mock<IUserService> _mockUserService;
        //private readonly UserController _controller;

        //public UserControllerTest()
        //{
        //    _mockUserService = new Mock<IUserService>();
        //    _controller = new UserController(_mockUserService.Object);
        //}

        //[Fact]
        //public async Task GetUser_ReturnsOkResult_WhenRequestIsValid()
        //{
        //    // Arrange
        //    var request = new GetUserRequestDto { IdUser = 2};
        //    var expectedResponse = new GetUserResponseDto
        //    {
        //        //Id = 1,
        //        //Name = "Test User",
        //        //Email = "test@example.com"
        //    };

        //    var successResponse = BaseResponse<GetUserResponseDto>.BaseResponseSuccess(expectedResponse);

        //    _mockUserService.Setup(service => service.GetUser(request))
        //                    .ReturnsAsync(successResponse);

        //    // Act
        //    var result = await _controller.GetUser(request);

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    var response = Assert.IsType<BaseResponse<GetUserResponseDto>>(okResult.Value);
        //    //Assert.True(response.);
        //    Assert.Equal(expectedResponse.Id, response.Data.Id);
        //}

        //[Fact]
        //public async Task AddUser_ReturnsOkResult_WhenRequestIsValid()
        //{
        //    //// Arrange
        //    //var request = new AddUserRequestDto();
        //    //_mockUserService.Setup(service => service.AddUser(request))
        //    //    .ReturnsAsync(new object()); // Ajusta el tipo de retorno según tu implementación real

        //    //// Act
        //    //var result = await _controller.AddUser(request);

        //    //// Assert
        //    //Assert.IsType<OkObjectResult>(result);
        //}

        //// Agrega más pruebas para los otros métodos (UpdateUser, DeleteUser, GetAllUser)

        //[Fact]
        //public async Task UpdateUser_ReturnsOkResult_WhenRequestIsValid()
        //{
        //    //// Arrange
        //    //var request = new UpdateUserRequestDto();
        //    //_mockUserService.Setup(service => service.UpdateUser(request))
        //    //    .ReturnsAsync(new object());

        //    //// Act
        //    //var result = await _controller.UpdateUser(request);

        //    //// Assert
        //    //Assert.IsType<OkObjectResult>(result);
        //}

        //[Fact]
        //public async Task DeleteUser_ReturnsOkResult_WhenRequestIsValid()
        //{
        //    //// Arrange
        //    //var request = new DeleteUserRequestDto();
        //    //_mockUserService.Setup(service => service.DeleteUser(request))
        //    //    .ReturnsAsync(new object());

        //    //// Act
        //    //var result = await _controller.DeleteUser(request);

        //    //// Assert
        //    //Assert.IsType<OkObjectResult>(result);
        //}

        //[Fact]
        //public async Task GetAllUser_ReturnsOkResult_WhenRequestIsValid()
        //{
        //    //// Arrange
        //    //var request = new GetAllUserRequestDto();
        //    //_mockUserService.Setup(service => service.GetAllUser(request))
        //    //    .ReturnsAsync(new object());

        //    //// Act
        //    //var result = await _controller.GetAllUser(request);

        //    //// Assert
        //    //Assert.IsType<OkObjectResult>(result);
        //}
    }
}