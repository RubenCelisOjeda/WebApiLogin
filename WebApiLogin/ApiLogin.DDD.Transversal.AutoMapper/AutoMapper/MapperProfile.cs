using ApiLogin.DDD.Application.Dto.User.Request.AddUser;
using ApiLogin.DDD.Domain.Entities.User.Request.AddUser;
using AutoMapper;

namespace ApiLogin.DDD.Transversal.AutoMapper.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region [User]

            //Add
            CreateMap<AddUserRequestDto, AddUserRequestEntities>(); 

            #endregion
        }
    }
}
