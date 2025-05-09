﻿namespace ApiLogin.Application.Dto.User.Request.AddUser
{
    public class AddUserRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModify { get; set; }
        public int? Status { get; set; }
    }
}
