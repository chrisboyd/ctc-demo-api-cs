using FluentValidation;
using MongoDB.Bson;

namespace WYWM.CTC.API.Activities.CourseReports.Queries.GetById;

public class Validator : AbstractValidator<Query>
{
    public Validator()
    {
        var objectId = new ObjectId();
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => ObjectId.TryParse(x.Id, out objectId))
            .Equal(true)
            .WithMessage("{PropertyValue} Provided id was not a valid MongoDB ObjectID");
    }
}
