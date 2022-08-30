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
            CreateMap<Team, GetTeamDto>().ReverseMap();
        }
    }
}
