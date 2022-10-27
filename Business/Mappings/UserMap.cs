using AutoMapper;
using Domain.Entities;
using Security.JWT.Services;

namespace Business.Mappings;
public class UserMap : Profile
{
    public UserMap()
    {
        CreateMap<RefreshRequest, User>();
    }
}
