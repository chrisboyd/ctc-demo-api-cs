using FluentValidation;

namespace WYWM.CTC.API.Activities.CourseReports.Commands.UpdateById;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }       
}
