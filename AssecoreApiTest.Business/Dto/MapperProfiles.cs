using AutoMapper;
using AssecoreApiTest.Data.Entities;

namespace AssecoreApiTest.Business.Dto
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
