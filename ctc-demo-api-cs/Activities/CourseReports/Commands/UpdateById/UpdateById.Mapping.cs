using AutoMapper;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.CourseReports.Commands.UpdateById;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<PerformanceObjective, Response>(MemberList.None)
            .ForMember(dest => dest.Name, opt
                => opt.MapFrom(src => src.Name));
    }
}
