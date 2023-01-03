using FluentValidation;

namespace  WYWM.CTC.API.Activities.PerformanceObjectives.Commands.Put;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
        
        // TODO: Add Validation for Object
    }       
}
