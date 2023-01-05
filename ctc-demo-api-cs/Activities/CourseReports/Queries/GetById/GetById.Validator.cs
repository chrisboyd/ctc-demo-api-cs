using FluentValidation;

namespace WYWM.CTC.API.Activities.CourseReports.Queries.GetById;

public class Validator : AbstractValidator<Query>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }       
}
