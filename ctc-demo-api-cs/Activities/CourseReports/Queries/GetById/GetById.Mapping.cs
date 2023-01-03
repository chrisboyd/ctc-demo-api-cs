using AutoMapper;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.CourseReports.Queries.GetById;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<PerformanceObjective, Response>(MemberList.None)
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt
                => opt.MapFrom(src => src.Name));
    }
}