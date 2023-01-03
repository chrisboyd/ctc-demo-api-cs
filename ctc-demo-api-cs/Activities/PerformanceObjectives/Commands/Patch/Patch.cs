using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Threenine.ApiResponse;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Commands.Patch;

[Route(Routes.PerformanceObjective)]
public class Patch : EndpointBaseAsync.WithRequest<Command>.WithActionResult<SingleResponse<Response>>
{
    private readonly IMediator _mediator;

    public Patch(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPatch("{id:guid}")]
    [SwaggerOperation(
        Summary = "Patch",
        Description = "Patch",
        OperationId = "f564d830-2160-471c-b51b-bb878b229a15",
        Tags = new[] { Routes.PerformanceObjective })
    ]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
    public override async Task<ActionResult<SingleResponse<Response>>> HandleAsync([FromRoute] Command request, CancellationToken cancellationToken = new())
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
