using AtmApp.API.Dtos;
using AtmApp.API.Models;
using AutoMapper;

namespace AtmApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AtmFleet, AtmFleetDto>();
            CreateMap<AtmForUpdateDto, AtmFleet>();
        }
    }
}