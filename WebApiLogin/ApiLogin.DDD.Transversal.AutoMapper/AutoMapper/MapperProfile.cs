using ApiLogin.DDD.Application.Dto.User.Request.AddUser;
using ApiLogin.DDD.Application.Dto.User.Request.DeleteUser;
using ApiLogin.DDD.Application.Dto.User.Request.GetAllUser;
using ApiLogin.DDD.Application.Dto.User.Request.GetUser;
using ApiLogin.DDD.Application.Dto.User.Request.UpdateUser;
using ApiLogin.DDD.Application.Dto.User.Response.Base.GetAllUser;
using ApiLogin.DDD.Application.Dto.User.Response.Base.GetUser;
using ApiLogin.DDD.Domain.Entities.User.Request.AddUser;
using ApiLogin.DDD.Domain.Entities.User.Request.DeleteUser;
using ApiLogin.DDD.Domain.Entities.User.Request.GetAllUser;
using ApiLogin.DDD.Domain.Entities.User.Request.GetUser;
using ApiLogin.DDD.Domain.Entities.User.Request.UpdateUser;
using ApiLogin.DDD.Domain.Entities.User.Response.GetAllUser;
using ApiLogin.DDD.Domain.Entities.User.Response.GetUser;
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
        }
    }
}
