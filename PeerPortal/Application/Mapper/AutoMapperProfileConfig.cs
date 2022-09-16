using Application.Shared.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    /// <summary>
    /// This class contains configuration for mapping between classes
    /// </summary>
    public class AutoMapperProfileConfig : Profile
    {
        public AutoMapperProfileConfig()
        {
            CreateMap<Team, GetTeamDto>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.TeamUsers.Select(x => x.ApplicationUser)));
            CreateMap<CreateTeamDto, Team>();
            CreateMap<ApplicationUser, GetUserDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));
            CreateMap<TeamUser, AddTeamUserDto>().ReverseMap();
        }
    }
}
