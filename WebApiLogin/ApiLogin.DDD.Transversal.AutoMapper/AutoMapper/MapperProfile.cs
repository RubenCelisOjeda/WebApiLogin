using ApiLogin.Application.Dto.Auth.Login.Request;
using ApiLogin.Application.Dto.Auth.SendCodeEmail.Request;
using ApiLogin.Application.Dto.User.Request.AddUser;
using ApiLogin.Application.Dto.User.Request.DeleteUser;
using ApiLogin.Application.Dto.User.Request.GetAllUser;
using ApiLogin.Application.Dto.User.Request.GetUser;
using ApiLogin.Application.Dto.User.Request.UpdateUser;
using ApiLogin.Application.Dto.User.Response.Base.GetAllUser;
using ApiLogin.Application.Dto.User.Response.Base.GetUser;
using ApiLogin.Domain.Entities.Auth.Request;
using ApiLogin.Domain.Entities.RecoveryPassword.Request.SendCodeEmail;
using ApiLogin.Domain.Entities.User.Request.AddUser;
using ApiLogin.Domain.Entities.User.Request.DeleteUser;
using ApiLogin.Domain.Entities.User.Request.GetAllUser;
using ApiLogin.Domain.Entities.User.Request.GetUser;
using ApiLogin.Domain.Entities.User.Request.UpdateUser;
using ApiLogin.Domain.Entities.User.Response.GetAllUser;
using ApiLogin.Domain.Entities.User.Response.GetUser;
using AutoMapper;

namespace ApiLogin.DDD.Transversal.AutoMapper.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region [User]

            #region [Request]
            //Add
            CreateMap<AddUserRequestDto, AddUserRequestEntities>();

            //Get
            CreateMap<GetUserRequestDto, GetUserRequestEntities>();

            //GetAll
            CreateMap<GetAllUserRequestDto, GetAllUserRequestEntities>();

            //Update
            CreateMap<UpdateUserRequestDto, UpdateUserRequestEntities>();

            //Delete
            CreateMap<DeleteUserRequestDto, DeleteUserRequestEntities>();
            #endregion

            #region [Response]
            //Get
            CreateMap<GetUserResponseEntities, GetUserResponseDto>();

            //GetAll
            CreateMap<GetAllUserResponseEntities, GetAllUserResponseDto>();
            #endregion

            #endregion

            #region [RecoveryPassword]

            #region [Request]
            //Add
            CreateMap<SendCodeEmailRequestDto, SendCodeEmailRequestEntities>();
            #endregion

            #region [Response]

            #endregion

            #endregion

            #region [Auth]

            #region [Request]
            //Add
            CreateMap<LoginRequestDto, LoginRequestEntities>();
            #endregion

            #region [Response]

            #endregion

            #endregion
        }
    }
}
