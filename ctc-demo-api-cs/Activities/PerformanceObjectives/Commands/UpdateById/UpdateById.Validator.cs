using FluentValidation;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Commands.UpdateById;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.UpdateEvalObjDto.Name).NotEmpty();
    }       
}
