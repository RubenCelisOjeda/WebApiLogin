﻿using ApiLogin.Application.Dto.User.Request.AddUser;
using ApiLogin.Application.Dto.User.Request.DeleteUser;
using ApiLogin.Application.Dto.User.Request.GetAllUser;
using ApiLogin.Application.Dto.User.Request.GetUser;
using ApiLogin.Application.Dto.User.Request.UpdateUser;
using ApiLogin.Application.Dto.User.Response.Base.GetAllUser;
using ApiLogin.Application.Dto.User.Response.Base.GetUser;
using ApiLogin.DDD.Transversal.Utils;

namespace ApiLogin.Application.Services.User
{
    public interface IUserService
    {
        public Task<BaseResponse<GetUserResponseDto>> GetUser(GetUserRequestDto request);
        public Task<BaseResponse<IEnumerable<GetAllUserResponseDto>>> GetAllUser(GetAllUserRequestDto request);
        public Task<BaseResponse<int>> AddUser(AddUserRequestDto request);
        public Task<BaseResponse<int>> UpdateUser(UpdateUserRequestDto request);
        public Task<BaseResponse<int>> DeleteUser(DeleteUserRequestDto request);
    }
}
