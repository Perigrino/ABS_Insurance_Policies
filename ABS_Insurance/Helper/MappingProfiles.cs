using ABS_Insurance.Data.Dto;
using ABS_Insurance.Model;
using AutoMapper;

namespace ABS_Insurance.Helper;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Policy,CreatePolicyDto>();
        CreateMap<CreatePolicyDto,Policy>();
        CreateMap<UpdatePolicyDto,Policy>();
        CreateMap<ComponentDto,Components>();
        CreateMap<CreateComponentDto,Components>();
        CreateMap<Components,ComponentDto>();
    }
}