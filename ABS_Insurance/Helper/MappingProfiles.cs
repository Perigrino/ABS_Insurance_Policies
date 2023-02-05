using ABS_Insurance.Data.Dto;
using ABS_Insurance.Model;
using AutoMapper;

namespace ABS_Insurance.Helper;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Policy,PolicyDto>();
        CreateMap<PolicyDto,Policy>();
        CreateMap<ComponentDto,Components>();
        CreateMap<Components,ComponentDto>();
    }
}