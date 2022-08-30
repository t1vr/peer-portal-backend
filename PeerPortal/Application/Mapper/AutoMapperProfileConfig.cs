using Application.ResponseModel;
using Domain.Entities;
using AutoMapper;

namespace Application.Mapper
{
    /// <summary>
    /// This class contains configuration for mapping between classes
    /// </summary>
    public class AutoMapperProfileConfig : Profile
    {
        public AutoMapperProfileConfig()
        {
            CreateMap<Team, TeamResponse>().ReverseMap();
        }
    }
}
