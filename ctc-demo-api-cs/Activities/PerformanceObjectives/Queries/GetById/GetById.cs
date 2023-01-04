using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Threenine.ApiResponse;

namespace WYWM.CTC.API.Activities.CourseReports.Queries.GetById;

[Route(Routes.PerformanceObjective)]
public class GetById : EndpointBaseAsync.WithRequest<Query>.WithActionResult<SingleResponse<Response>>
{
    private readonly IMediator _mediator;

    public GetById(IMediator mediator)
    {
        _mediator = mediator;
    }
        
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "GetById",
        Description = "GetById",
        OperationId = "089de2f7-39bd-48a7-a56e-649e93189690",
        Tags = new[] { Routes.PerformanceObjective})
    ]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
    [ProducesErrorResponseType(typeof(BadRequestObjectResult))]
    public override async Task<ActionResult<SingleResponse<Response>>> HandleAsync([FromRoute] Query request, CancellationToken cancellationToken = new())
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
