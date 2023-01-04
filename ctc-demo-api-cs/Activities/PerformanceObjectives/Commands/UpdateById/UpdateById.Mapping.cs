using AutoMapper;
using WYWM.CTC.API.Activities.PerformanceObjectives.Domain;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Commands.UpdateById;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<UpdateEvalObjDto, Response>(MemberList.None)
            .ForMember(dest => dest.Name, opt
                => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Passed, opt
                => opt.MapFrom(src => src.Passed))
            .ForMember(dest => dest.Comments, opt
                => opt.MapFrom(src => src.Comments));
    }
}
