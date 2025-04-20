namespace ApiLogin.Domain.Entities.User.Request.AddUser
{
    public class AddUserRequestEntities
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModify { get; set; }
        public int Status { get; set; }
    }
}
