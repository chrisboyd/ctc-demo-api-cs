using AutoMapper;
using WYWM.CTC.API.Activities.PerformanceObjectives.Domain;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Queries.GetById;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<PerformanceObjective, Response>(MemberList.None)
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt
                => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.EvaluationObjectives, opt
                => opt.MapFrom(src => src.EvaluationObjectives));
    }
}