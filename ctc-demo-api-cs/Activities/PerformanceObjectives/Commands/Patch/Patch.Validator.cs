using FluentValidation;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Commands.Patch;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();     
    }       
}
