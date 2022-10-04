using AutoMapper;
using MetricsManager.Models;
using MetricsManager.Models.Dto;

namespace MetricsManager
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AgentInfo, AgentInfoDto>();
            CreateMap<AgentInfoDto, AgentInfo>();
        }
    }
}