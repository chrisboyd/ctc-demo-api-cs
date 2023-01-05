using AutoMapper;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.CourseReports.Commands.SaveCourseReport;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<CourseReport, Response>(MemberList.None)
            .ForMember(dest => dest.InstructorEmail, opt
                => opt.MapFrom(src => src.InstructorEmail))
            .ForMember(dest => dest.StudentEmail, opt
                => opt.MapFrom(src => src.StudentEmail))
            .ForMember(dest => dest.Grade, opt
                => opt.MapFrom(src => src.Grade))
            .ForMember(dest => dest.PerformanceObjectiveName, opt
                => opt.MapFrom(src => src.PerformanceObjectiveName))
            .ForMember(dest => dest.ResultsId, opt
                => opt.MapFrom(src => src.ResultsId));
    }
}
