using FluentValidation;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Queries.GetbyId;

public class Validator : AbstractValidator<Query>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }       
}
