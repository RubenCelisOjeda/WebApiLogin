namespace ApiLogin.Application.Dto.User.Request.UpdateUser
{
    public class UpdateUserRequestDto
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public DateTime? DateModify { get; set; }
        public int Status { get; set; }
    }
}
