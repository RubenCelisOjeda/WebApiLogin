namespace ApiLogin.DDD.Application.Dto.User.Response.Base.GetAllUser
{
    public class GetAllUserResponseDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DateCreated { get; set; }
        public string DateModify { get; set; }
        public string Status { get; set; }
    }
}
