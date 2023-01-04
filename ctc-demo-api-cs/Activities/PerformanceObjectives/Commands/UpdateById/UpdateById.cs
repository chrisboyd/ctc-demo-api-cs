using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Threenine.ApiResponse;

namespace WYWM.CTC.API.Activities.CourseReports.Commands.UpdateById;

[Route(Routes.PerformanceObjective)]
public class UpdateById : EndpointBaseAsync.WithRequest<Command>.WithActionResult<SingleResponse<Response>>
{
    private readonly IMediator _mediator;

    public UpdateById(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPatch("{id}")]
    [SwaggerOperation(
        Summary = "UpdateById",
        Description = "UpdateById",
        OperationId = "b48f45c5-5fa8-4e7e-b4f1-0c0d536dcee6",
        Tags = new[] { Routes.PerformanceObjective })
    ]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override async Task<ActionResult<SingleResponse<Response>>> HandleAsync([FromRoute] Command request, 
        CancellationToken cancellationToken = new())
    {
        var result = await _mediator.Send(request, cancellationToken);

        if (result.IsValid)
            return new OkObjectResult(result.Item);

        return await HandleErrors(result.Errors);
    }
    
    private Task<ActionResult> HandleErrors(List<KeyValuePair<string, string[]>> errors)
    {
        ActionResult result = null;
        errors.ForEach(error =>
        {
            result = error.Key switch
            {
                ErrorKeyNames.Conflict => new ConflictResult(),
                _ => new BadRequestObjectResult(errors)
            };
        });
        return Task.FromResult(result);
    }
}
