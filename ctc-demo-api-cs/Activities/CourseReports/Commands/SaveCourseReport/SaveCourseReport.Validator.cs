using FluentValidation;
namespace WYWM.CTC.API.Activities.CourseReports.Commands.SaveCourseReport;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.SaveCourseReportDto.Grade).LessThanOrEqualTo(1);
    }       
}
