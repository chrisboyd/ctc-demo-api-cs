using FluentValidation;

namespace WYWM.CTC.API.Activities.CourseReports.Queries.GetInstructorReports;

public class Validator : AbstractValidator<Query>
{
    public Validator()
    {
        RuleFor(x => x.InstructorEmail).NotEmpty();
        RuleFor(x => x.InstructorEmail).EmailAddress();
    }       
}
